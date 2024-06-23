using BugTrackerV1.Models;
using BugTrackerV1.Models.ViewModel;
using BugTrackerV1.Models.ViewModel.Issue;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Net.Mail;
using System.Security.Claims;

namespace BugTrackerV1.Controllers
{
    public class IssueController: Controller
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;

        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        public IssueController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index(string searchString = null)
        {
            var priorityImages = new Dictionary<string, string>
            {
                { "Высокий", "/img/priority/high.svg" },
                { "Средний", "/img/priority/medium.svg" },
                { "Низкий", "/img/priority/low.svg" }
            };

            var model = _context.Issue.Select(i => new IssueViewModel
            {
                Id = i.Id,
                Title = i.Title,
                CreatedBy = i.CreatedBy,
                AssignedTo = i.AssignedTo,
                Priority = i.Priority.NamePriority,
                PriorityImage = priorityImages.ContainsKey(i.Priority.NamePriority)
                                ? priorityImages[i.Priority.NamePriority]
                                : "/images/priority-default.png",
                Status = i.Status.NameStatus,
                Created = i.CreatedAt,
                Updated = i.UpdatedAt,
            }).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(m => m.Title.Contains(searchString)).ToList();
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateIssueViewModel
            {
                Priority = _context.IssuePriority.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.NamePriority
                }).ToList(),

                Status = _context.IssueStatus.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.NameStatus
                }).ToList(),

                Type = _context.IssueType.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.NameType
                }).ToList(),

                CreatedBy = _context.User.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = $"{u.LastName} {u.FirstName}"
                }).ToList(),

                AssignedToBy = _context.User.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = $"{u.LastName} {u.FirstName}"
                }).ToList(),

                Labels = _context.Label.Select(u => new Filter
                {
                    Id = u.Id,
                    Name = $"{u.NameLabel}",
                    Selected = false
                }).ToArray()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIssueViewModel viewModel)
        {

            var issue = new Issue
            {
                Title = viewModel.Title,
                PriorityId = viewModel.PriorityId,
                StatusId = 1,
                TypeId = viewModel.TypeId,
                CreatedById = viewModel.CreatedById,
                AssignedToId = viewModel.AssignedToId,
                ProjectId = int.Parse(User.FindFirst("SelectedProjectId").Value),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Issue.Add(issue);

            if (viewModel.Attachments.Count > 0)
            {
                foreach (var attachment in viewModel.Attachments)
                {
                    if (attachment.Length > 0)
                    {
                        var path = Path.Combine(_environment.ContentRootPath, "Uploads", attachment.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await attachment.CopyToAsync(stream);
                        }

                        var issueAttachment = new IssueAttachment
                        {
                            NameAttachment = attachment.FileName,
                            UploadedAt = DateTime.Now,
                            UploadedById = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value), // Или другой соответствующий идентификатор
                            Link = path,
                            Size = attachment.Length,
                            FileFormat = Path.GetExtension(attachment.FileName),
                            Issue = issue
                        };

                        _context.Add(issueAttachment);
                    }
                }
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "Issue");
        }

        [HttpGet]
        public IActionResult Detail(int issueId)
        {
            var issue = _context.Issue.FirstOrDefault(x => x.Id == issueId);

            if (issue == null)
                return RedirectToAction(nameof(Index));

            var model = new DetailIssueViewModel
            {
                Id = issue.Id,
                Title = issue.Title,
                Description = issue.Description,
                CreatedBy = issue.CreatedBy.LastName,
                AssignedTo = issue.AssignedTo?.LastName,
                Priority = issue.Priority.NamePriority,
                Status = issue.Status.NameStatus,
                Type = issue.Type.NameType,
                SprintId = issue.SprintId,
                Sprints = _context.Sprint.Where(x => x.ProjectId == int.Parse(User.FindFirst("SelectedProjectId").Value)).Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameSprint
                }).ToList(),
            };
            model.Attachments = issue.IssueAttachment.Select(x => new FileViewModel 
            {
                FileName = x.NameAttachment,
                Size = x.Size,
                FileFormat = x.FileFormat,
                FilePath = x.Link
            }).ToList();


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Detail(DetailIssueViewModel viewModel)
        {
            var issue = _context.Issue.FirstOrDefault(x => x.Id == viewModel.Id);
            if (issue == null)
            {
                return View("Error");
            }


            issue.SprintId = viewModel.SprintId;
            await _context.SaveChangesAsync();



            return RedirectToAction("Index", "Issue");
        }

        public async Task<IActionResult> GetFile(string fileName)
        {
            var filePath = Path.Combine(_uploadFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), fileName);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx", "application/vnd.openxmlformats.officedocument.spreadsheetml.sheet"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"},
            {".csv", "text/csv"}
        };
        }
    }
}
