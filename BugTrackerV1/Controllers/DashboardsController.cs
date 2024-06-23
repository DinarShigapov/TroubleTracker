using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Authorization;
using BugTrackerV1.Filters;
using Microsoft.EntityFrameworkCore;
using BugTrackerV1.Models;

namespace AspnetCoreMvcFull.Controllers;

[Authorize]
[ServiceFilter(typeof(EnsureProjectSelectedFilter))]
public class DashboardsController : Controller
{
    private readonly ApplicationContext _context;

    public DashboardsController(ApplicationContext context)
    {
        _context = context;
    }

    
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetTotalRevenueData()
    {
        var data = _context.Issue
                    .Select(g => g.Id).ToList();

        return Json(data);
    }

    [HttpGet]
    public IActionResult GetGrowthData()
    {
        var growth = _context.Issue 
                    .Select(g => g.Id)
                    .FirstOrDefault();

        return Json(new { GrowthPercentage = growth });
    }
}
