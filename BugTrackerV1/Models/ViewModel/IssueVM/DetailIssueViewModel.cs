using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTrackerV1.Models.ViewModel.Issue
{
    public class DetailIssueViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Priority { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
        public int? SprintId { get; set; }
        public IEnumerable<SelectListItem> Sprints { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Labels { get; set; }
        public List<FileViewModel> Attachments { get; set; } = new List<FileViewModel>();
        public List<IssueComment> Comments { get; set; } = new List<IssueComment>();
    }
}
