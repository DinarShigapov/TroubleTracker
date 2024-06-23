using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Authorization;
using BugTrackerV1.Filters;

namespace AspnetCoreMvcFull.Controllers;

[Authorize]
[ServiceFilter(typeof(EnsureProjectSelectedFilter))]
public class UIController : Controller
{
    public IActionResult Modals() => View();
}
