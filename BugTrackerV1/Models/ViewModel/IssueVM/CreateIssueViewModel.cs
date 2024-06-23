using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.Issue
{
    public class CreateIssueViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int PriorityId { get; set; }
        public IEnumerable<SelectListItem> Priority { get; set; }

        public int StatusId { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public int TypeId { get; set; }
        public IEnumerable<SelectListItem> Type { get; set; }

        public int CreatedById { get; set; }
        public IEnumerable<SelectListItem> CreatedBy { get; set; }
        public int AssignedToId { get; set; }
        public IEnumerable<SelectListItem> AssignedToBy { get; set; }
        public Filter[] Labels { get; set; }
        public List<IFormFile> Attachments { get; set; } = new List<IFormFile>();

    }
}
