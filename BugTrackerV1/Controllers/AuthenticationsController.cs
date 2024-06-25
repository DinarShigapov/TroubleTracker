using BugTrackerV1.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BugTrackerV1.Models;
using BugTrackerV1.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BugTrackerV1.Services;

namespace BugTrackerV1.Controllers
{
    public class AuthenticationsController : Controller
    {

        private readonly IPermissionService _permissionService;
        private readonly ApplicationContext _context;
        private readonly IProjectService _projectService;

        public AuthenticationsController(ApplicationContext context, IProjectService projectService, IPermissionService permissionService)
        {
            _permissionService = permissionService;
            _context = context;
            _projectService = projectService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Authorization()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authorization(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await AuthenticateUserAsync(model.Email, model.Password);
                if (user != null)
                {
                    var userPermissions = await _permissionService.GetUserPermissionsAsync(user.Id);
                    
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.LastName} {user.FirstName}"),
                        new Claim("SelectedProjectId", user?.ProjectUsers == null ? user.Project.ToList()[0].Id.ToString() : "")
                    };

                    if (user.UserRoles.FirstOrDefault(x => x.UserId == user.Id) != null) 
                    {
                        claims.Add(new Claim("Role", user.UserRoles.FirstOrDefault(x =>x.UserId == user.Id).Role.NameRole));
                    }

                    if (userPermissions != null) 
                    {
                        
                        claims.AddRange(userPermissions.Select(p => new Claim("Permission", p)));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Check if the user has a selected project
                    var selectedProject = _projectService.GetSelectedProject(HttpContext);
                    if (!selectedProject.HasValue)
                    {
                        return RedirectToAction("Index", "Project");
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Authentications");
        }

        private async Task<User> AuthenticateUserAsync(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email && x.PasswordHash == password);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistViewModel model)
        {

            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Patronymic = model.Patronymic,
                    Email = model.Email,
                    PasswordHash = model.Password
                };

                _context.User.Add(newUser);
                _context.SaveChangesAsync();

                return RedirectToAction("Authorization");
            }

            return View(model);
        }
    }
}
