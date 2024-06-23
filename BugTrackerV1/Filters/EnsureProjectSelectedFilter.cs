using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BugTrackerV1.Interfaces;

namespace BugTrackerV1.Filters
{
    public class EnsureProjectSelectedFilter : IActionFilter
    {
        private readonly IProjectService _projectService;

        public EnsureProjectSelectedFilter(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
            if (path.StartsWithSegments("/Authentications") || path.StartsWithSegments("/Project"))
            {
                return;
            }

            var selectedProjectId = _projectService.GetSelectedProject(context.HttpContext);
            if (!selectedProjectId.HasValue)
            {
                context.Result = new RedirectToActionResult("Index", "Project", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
