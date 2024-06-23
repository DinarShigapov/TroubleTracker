using BugTrackerV1.Filters;
using BugTrackerV1.Interfaces;
using BugTrackerV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace BugTrackerV1.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EnsureProjectSelectedFilter))]
    public class ProjectController : Controller
    {

        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
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
    }
}
