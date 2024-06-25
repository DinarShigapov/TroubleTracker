using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTrackerV1.Models.ViewModel.IssueVM
{
    public class DetailIssueViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Priority { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public UserViewModel CreatedBy { get; set; }
        public UserViewModel? AssignedTo { get; set; }
        public int? SprintId { get; set; }
        public IEnumerable<SelectListItem> Sprints { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<string> Labels { get; set; } = new List<string>();
        public List<FileViewModel> Attachments { get; set; } = new List<FileViewModel>();
        public CommentViewModel Comment { get; set; }
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}
