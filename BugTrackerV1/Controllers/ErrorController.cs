using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerV1.Controllers
{
    [Authorize]
    [Route("error")]
    public class ErrorController: Controller
	{
		[Route("404")]
		public IActionResult PageNotFound()
		{
			string originalPath = "unknown";
			if (HttpContext.Items.ContainsKey("originalPath"))
			{
				originalPath = HttpContext.Items["originalPath"] as string;
			}
			return View();
		}
	}
}
