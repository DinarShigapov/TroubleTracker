using BugTrackerV1.Interfaces;
using BugTrackerV1.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerV1.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationContext _context;

        public PermissionService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUserPermissionsAsync(int userId)
        {
            var rolePermissions = from role in _context.Role
                                  join rolePermission in _context.RolePermissions on role.Id equals rolePermission.RoleId
                                  join userRole in _context.UserRoles on role.Id equals userRole.RoleId
                                  where userRole.UserId == userId
                                  select rolePermission.Permission.KeyPermission;

            var userPermissions = from userPermission in _context.UserPermissions
                                  where userPermission.UserId == userId
                                  select userPermission.Permission.KeyPermission;

            var fds = rolePermissions.ToList();

            return await rolePermissions.Union(userPermissions).ToListAsync();
        }
    }
}
