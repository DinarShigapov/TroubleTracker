using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Authorization;
using BugTrackerV1.Filters;


namespace BugTrackerV1.Controllers
{
    [Authorize]
    public class AccountController: Controller
    {
        [SkipFilter]
        public IActionResult Settings() => View();
    }
}
