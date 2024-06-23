using System.Diagnostics;
using AspnetCoreMvcFull.Models;
using BugTrackerV1.Filters;
using BugTrackerV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AspnetCoreMvcFull.Controllers;

[Authorize]
[ServiceFilter(typeof(EnsureProjectSelectedFilter))]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private ApplicationContext _context;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
       
        if (HttpContext.Request.Path != "/")
        {
            return RedirectPermanent("/");
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
