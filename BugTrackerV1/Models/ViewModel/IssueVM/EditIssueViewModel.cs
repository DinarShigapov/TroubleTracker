using BugTrackerV1.Models.ViewModel.IssueVM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTrackerV1.Models.ViewModel.IssueVM
{
    public class EditIssueViewModel
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

        public int AssignedToId { get; set; }
        public IEnumerable<SelectListItem> AssignedToBy { get; set; }

        public List<FileViewModel> Attachments { get; set; } = new List<FileViewModel>();
        public List<IFormFile> NewAttachments { get; set; } = new List<IFormFile>();

    }
}
