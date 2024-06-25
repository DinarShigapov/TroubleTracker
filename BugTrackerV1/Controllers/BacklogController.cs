using BugTrackerV1.Filters;
using BugTrackerV1.Models;
using BugTrackerV1.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerV1.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EnsureProjectSelectedFilter))]
    [Authorize(Policy = "TracVw")]
    public class BacklogController: Controller
    {

        private readonly ApplicationContext _context;

        public BacklogController(ApplicationContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            Sprint? activeSprint = null;
            var projectId = int.Parse(User.FindFirst("SelectedProjectId").Value);
            var project = _context.Project.FirstOrDefault(x => x.Id == projectId);
            if (project.Sprint != null)
            {
                activeSprint = project.Sprint;
            }

            var today = DateTime.Today;
            var futureSprints = _context.Sprint
                .Where(sprint => sprint.EndDate >= today && sprint.StartDate >= today && sprint.Project.ActiveSprintId != sprint.Id).ToList();


            var backlogTasks = _context.Issue.Where(t => t.SprintId == null && t.ProjectId == projectId).ToList();

            var viewModel = new BacklogViewModel
            {
                ActiveSprint = activeSprint,
                FutureSprints = futureSprints,
                BacklogTasks = backlogTasks
            };

            return View(viewModel);
        }

        public IActionResult CreateSprint()
        {
            ViewBag.Projects = _context.Project.ToList();
            var model = new SprintViewModel
            {
                StartDate = DateTime.Today.AddDays(1),
                EndDate = DateTime.Today.AddDays(2) 
            };
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> SetStartSprint(int sprintId) 
        {
            var card = await _context.Sprint.FirstOrDefaultAsync(x => x.Id == sprintId);
            if (card.Project.ActiveSprintId == null)
            {
                card.Project.ActiveSprintId = card.Id;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> CompleteSprint(int sprintId) 
        {
            var card = await _context.Sprint.FirstOrDefaultAsync(x => x.Id == sprintId);
            if (card.Project.ActiveSprintId != null)
            {
                card.Project.ActiveSprintId = null;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSprint(SprintViewModel model)
        {
            if (model.StartDate < DateTime.Today.AddDays(1))
            {
                ModelState.AddModelError("StartDate", "Дата начала спринта не может быть ранее завтрашнего дня.");
            }

            if (ModelState.IsValid)
            {
                var sprint = new Sprint
                {
                    NameSprint = model.NameSprint,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    ProjectId = int.Parse(User.FindFirst("SelectedProjectId").Value)
                };

                _context.Sprint.Add(sprint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Projects = _context.Project.ToList();
            return View(model);
        }

    }
}
