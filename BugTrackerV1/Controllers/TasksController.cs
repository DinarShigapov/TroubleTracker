using BugTrackerV1.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerV1.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(EnsureProjectSelectedFilter))]
    public class TasksController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
