using BugTrackerV1.Interfaces;
using BugTrackerV1.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BugTrackerV1.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationContext _context;

        public ProjectService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Project> GetProjectsForUser(int userId)
        {
            return _context.Project.Where(p => p.ProjectUsers.Any(u => u.Id == userId)).ToList();
        }
        public async void SetSelectedProject(int projectId, HttpContext context)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
            {
                return;
            }

            var existingClaim = claimsIdentity.FindFirst("SelectedProjectId");

            if (existingClaim != null)
            {
                claimsIdentity.RemoveClaim(existingClaim);
            }

            claimsIdentity.AddClaim(new Claim("SelectedProjectId", projectId.ToString()));

            var userPrincipal = new ClaimsPrincipal(claimsIdentity);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
        }

        public int? GetSelectedProject(HttpContext context)
        {
            var selectedProjectClaim = context.User.FindFirst("SelectedProjectId");
            if (selectedProjectClaim != null && int.TryParse(selectedProjectClaim.Value, out var projectId))
            {
                return projectId;
            }
            return null;
        }


    }
}
