using BugTrackerV1.Models.ViewModel.PermissionVM;
using BugTrackerV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTrackerV1.Models.ViewModel.RoleVM;

namespace BugTrackerV1.Controllers
{
    public class RolesController: Controller
    {
        private readonly ApplicationContext _context;

        public RolesController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var viewModel = new AssignRoleViewModel
            {
                Users = await _context.User.ToListAsync(),
                Roles = await _context.Role.ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Roles/Assign
        [HttpPost]
        public async Task<IActionResult> Assign(AssignRoleViewModel model)
        {
            var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == model.SelectedUserId);
            if (model.SelectedRoleId != 0)
            {
                if (userRole != null)
                {
                    userRole.RoleId = model.SelectedRoleId;
                }
                else
                {
                    _context.UserRoles.Add(new UserRoles { UserId = model.SelectedUserId, RoleId = model.SelectedRoleId });
                }
            }
            else
            {
                if (userRole != null)
                {
                    _context.UserRoles.Remove(userRole);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View(new Models.ViewModel.RoleVM.CreateRoleViewModel());
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.ViewModel.RoleVM.CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new Role
                {
                    NameRole = model.NameRole,
                    Description = model.Description
                };

                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
