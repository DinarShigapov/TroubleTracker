using BugTrackerV1.Filters;
using BugTrackerV1.Models;
using BugTrackerV1.Models.ViewModel;
using BugTrackerV1.Models.ViewModel.KanbanVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerV1.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EnsureProjectSelectedFilter))]
    public class ActiveSprintController : Controller
    {
        private ApplicationContext _context;

        public ActiveSprintController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIssueStatus(int issueId, int newStatusId)
        {
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var projectId = int.Parse(User.FindFirst("SelectedProjectId").Value);

            var priorityImages = new Dictionary<string, string>
            {
                { "Высокий", "/img/priority/high.svg" },
                { "Средний", "/img/priority/medium.svg" },
                { "Низкий", "/img/priority/low.svg" }
            };

            var typeImages = new Dictionary<string, string>
            {
                { "Баг", "/img/status/bug-status.svg" },
                { "История", "/img/status/history-status.svg" },
                { "Задача", "/img/status/task-status.svg" }
            };
            var buffer = await _context.IssueStatus.ToListAsync();
            var viewmodel = new KanbanViewModel();
            viewmodel.Kanbans = new List<KanbanColumnViewModel>();


            if (_context.Project.Any(x => x.Id == projectId && x.Sprint != null))
            {
                var activesprint = _context.Sprint.FirstOrDefault(x => x.Project.ActiveSprintId == x.Id && x.ProjectId == projectId);

                var list = buffer.Select(x => new KanbanColumnViewModel()
                {
                    StatusId = x.Id,
                    NameStatus = x.NameStatus,
                    Cards = x.Issue.Where(c => c.ProjectId == projectId && c.SprintId == activesprint.Id).Select(z => new KanbanCardViewModel()
                    {
                        Id = z.Id,
                        Title = z.Title,
                        AssignedTo = z.AssignedTo.ToString(),
                        Description = z.Description,
                        Status = z.Status.NameStatus,
                        Priority = z.Priority.NamePriority,
                        Type = z.Type.NameType,
                        TypeImage = typeImages.ContainsKey(z.Type.NameType)
                                    ? typeImages[z.Type.NameType]
                                    : "/images/priority-default.png",
                        PriorityImage = priorityImages.ContainsKey(z.Priority.NamePriority)
                                    ? priorityImages[z.Priority.NamePriority]
                                    : "/images/priority-default.png",

                    }).ToList()
                }).ToList();
                viewmodel.Kanbans = list.ToList();

            }

            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult UpdateCardStatus(int cardId, int newStatusId)
        {
            var card = _context.Issue.Find(cardId);
            if (card.StatusId != newStatusId) 
            {
                card.StatusId = newStatusId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return Content("Wrong");
        }
    }
}