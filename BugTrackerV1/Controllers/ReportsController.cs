using BugTrackerV1.Models;
using BugTrackerV1.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BugTrackerV1.Controllers
{
    [Authorize(Policy = "TracVwRep")]
    public class ReportsController: Controller
    {
        private readonly ApplicationContext _context;

        public ReportsController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var issues = await _context.Issue.ToListAsync();

            var viewModel = new ReportViewModel
            {
                IssueCount = issues.Count,
                OpenIssueCount = issues.Count(i => i.StatusId == 1),
                ClosedIssueCount = issues.Count(i => i.StatusId == 2),
                InProgressIssueCount = issues.Count(i => i.StatusId == 3),
                IssuesBySprint = issues.Where(x => x.SprintId != null).GroupBy(i => i.Sprint.NameSprint).ToDictionary(g => g.Key, g => g.Count()),
                IssuesByUser = issues.Where(x => x.SprintId != null).GroupBy(i => i.AssignedTo.LastName).ToDictionary(g => g.Key, g => g.Count()),
                IssuesByProject = issues.Where(x => x.SprintId != null).GroupBy(i => i.Sprint.Project.NameProject).ToDictionary(g => g.Key, g => g.Count())
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DownloadHtmlReport()
        {
            var issues = await _context.Issue.ToListAsync();

            var viewModel = new ReportViewModel
            {
                IssueCount = issues.Count,
                OpenIssueCount = issues.Count(i => i.StatusId == 1),
                ClosedIssueCount = issues.Count(i => i.StatusId == 2),
                InProgressIssueCount = issues.Count(i => i.StatusId == 3),
                IssuesBySprint = issues.Where(x => x.SprintId != null).GroupBy(i => i.Sprint.NameSprint).ToDictionary(g => g.Key, g => g.Count()),
                IssuesByUser = issues.Where(x => x.SprintId != null).GroupBy(i => i.AssignedTo.LastName).ToDictionary(g => g.Key, g => g.Count()),
                IssuesByProject = issues.Where(x => x.SprintId != null).GroupBy(i => i.Sprint.Project.NameProject).ToDictionary(g => g.Key, g => g.Count())
            };

            var htmlContent = await RenderViewToStringAsync("Index", viewModel);
            var byteArray = Encoding.UTF8.GetBytes(htmlContent);
            var stream = new MemoryStream(byteArray);

            return File(stream, "application/octet-stream", "Report.html");
        }

        private async Task<string> RenderViewToStringAsync(string viewName, object model)
        {
            //ViewData.Model = model;
            //using var writer = new StringWriter();
            //var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

            //if (viewResult.View == null)
            //{
            //    throw new ArgumentNullException($"View {viewName} not found");
            //}

            //var viewContext = new ViewContext(
            //    ControllerContext,
            //    viewResult.View,
            //    ViewData,
            //    TempData,
            //    writer,
            //    new HtmlHelperOptions()
            //);

            //await viewResult.View.RenderAsync(viewContext);
            //return writer.GetStringBuilder().ToString();
            return null;
        }
    }
}
