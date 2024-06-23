using BugTrackerV1.Authorization;
using BugTrackerV1.Interfaces;
using BugTrackerV1.Services;
using Microsoft.AspNetCore.Authorization;

namespace BugTrackerV1.Handlers
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionService _permissionService;

        public PermissionHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userId = int.Parse(context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                var permissions = await _permissionService.GetUserPermissionsAsync(userId);

                if (permissions.Contains(requirement.Permission))
                {
                    context.Succeed(requirement);
                }
            }

            await Task.CompletedTask;
        }
    }
}
