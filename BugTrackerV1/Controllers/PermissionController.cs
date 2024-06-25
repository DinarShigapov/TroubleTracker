using BugTrackerV1.Models.ViewModel.PermissionVM;
using BugTrackerV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerV1.Controllers
{
    public class PermissionController : Controller
    {
        private readonly ApplicationContext _context;

        public PermissionController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _context.Role.ToListAsync();
            var users = await _context.User.ToListAsync();

            var viewModel = new PermissionViewModel
            {
                Roles = new List<RolePermissionViewModel>(),
                Users = new List<UserPermissionViewModel>(),
                AllRoles = roles.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.NameRole }).ToList(),
                AllUsers = users.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = $"{u.FirstName} {u.LastName}" }).ToList(),
            };
            return View(viewModel);
        }



        public async Task<IActionResult> GetRolePermissions(int roleId)
        {
            var role = await _context.Role
                .FirstOrDefaultAsync(r => r.Id == roleId);

            if (role == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permission.ToListAsync();

            var model = new RolePermissionViewModel
            {
                RoleId = role.Id,
                RoleName = role.NameRole,
                Permissions = permissions.Select(p => new PermissionCheckboxViewModel
                {
                    PermissionId = p.Id,
                    PermissionName = p.NamePermission,
                    IsSelected = role.RolePermissions.Any(rp => rp.PermissionId == p.Id)
                }).ToList()
            };

            return PartialView("_RolePermissionsPartial", model);
        }

        public async Task<IActionResult> GetUserPermissions(int userId)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permission.ToListAsync();

            var model = new UserPermissionViewModel
            {
                UserId = user.Id,
                UserName = $"{user.FirstName} {user.LastName}",
                Permissions = permissions.Select(p => new PermissionCheckboxViewModel
                {
                    PermissionId = p.Id,
                    PermissionName = p.NamePermission,
                    IsSelected = user.UserPermissions.Any(up => up.PermissionId == p.Id)
                }).ToList()
            };

            return PartialView("_UserPermissionsPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRolePermissions(RolePermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rolePermissions = _context.RolePermissions.Where(rp => rp.RoleId == model.RoleId);
                _context.RolePermissions.RemoveRange(rolePermissions);
                foreach (var permission in model.Permissions.Where(p => p.IsSelected))
                {
                    _context.RolePermissions.Add(new RolePermissions { RoleId = model.RoleId, PermissionId = permission.PermissionId });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserPermissions(UserPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userPermissions = _context.UserPermissions.Where(up => up.UserId == model.UserId);
                _context.UserPermissions.RemoveRange(userPermissions);
                foreach (var permission in model.Permissions.Where(p => p.IsSelected))
                {
                    _context.UserPermissions.Add(new UserPermissions { UserId = model.UserId, PermissionId = permission.PermissionId });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }

}
