using BugTrackerV1.Filters;
using BugTrackerV1.Interfaces;
using BugTrackerV1.Models;
using BugTrackerV1.Models.ViewModel.IssueVM;
using BugTrackerV1.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using BugTrackerV1.Models.ViewModel.ProjectVM;

namespace BugTrackerV1.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EnsureProjectSelectedFilter))]
    public class ProjectController : Controller
    {

        private readonly IProjectService _projectService;
        private readonly ApplicationContext _context;

        public ProjectController(IProjectService projectService, ApplicationContext context)
        {
            _projectService = projectService;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var projects = _projectService.GetProjectsForUser(userId);

            if (projects != null)
            {
                return View(projects);
            }
            return View();

        }
        public IActionResult Select(int projectId)
        {
            _projectService.SetSelectedProject(projectId, HttpContext);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var newProject = new Project()
                {
                    NameProject = model.Title,
                    Description = model.Description,
                    KeyProject = model.Key,
                    CreatedAt = DateTime.Now,
                    ProjectManagerId = userId,
                };

                _context.Project.Add(newProject);

                _context.ProjectUsers.Add(new ProjectUsers() 
                {
                    Project = newProject,
                    UserId = userId,
                });
                
                _context.SaveChanges();

                return RedirectToAction("Index"); 
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int projectId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var project = await _context.Project.FindAsync(projectId);
            if (project == null)
            {
                return NotFound();
            }

            var users = await _context.User.Where(x => x.Id != userId).ToListAsync();
            var projectUsers = await _context.ProjectUsers.Where(pu => pu.ProjectId == projectId).Select(pu => pu.UserId).ToListAsync();

            var model = new ProjectUserViewModel
            {
                ProjectId = projectId,
                ProjectName = project.NameProject,
                ProjectKey = project.KeyProject,
                ProjectDescription = project.Description,
                SelectedUserIds = projectUsers,
                UsersInProject = users.Where(u => projectUsers.Contains(u.Id))
                                      .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.ShortNameUser }).ToList(),
                UsersOutOfProject = users.Where(u => !projectUsers.Contains(u.Id))
                                         .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.ShortNameUser }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectUserViewModel model)
        {
            var project = await _context.Project.FindAsync(model.ProjectId);
            if (project == null)
            {
                return NotFound();
            }

            project.NameProject = model.ProjectName;
            project.KeyProject = model.ProjectKey;
            project.Description = model.ProjectDescription;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Project");
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(int projectId, int userId)
        {
            _context.ProjectUsers.Add(new ProjectUsers { ProjectId = projectId, UserId = userId });
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(int projectId, int userId)
        {
            var projectUser = await _context.ProjectUsers.FirstOrDefaultAsync(pu => pu.ProjectId == projectId && pu.UserId == userId);
            if (projectUser != null)
            {
                _context.ProjectUsers.Remove(projectUser);
                await _context.SaveChangesAsync();
            }
            return Json(new { success = true });
        }
    }
}
