using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTrackerV1.Models.ViewModel.Issue
{
    public class IssueViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string PriorityImage { get; set; }
        public string Status { get; set; }
        public User CreatedBy { private get; set; }
        public string CreatedByFullName => CreatedBy.ShortNameUser;
        public User? AssignedTo { get; set; }
        public string AssignedToFullName => AssignedTo != null ? AssignedTo.ShortNameUser : null;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<FileViewModel> Attachment = new List<FileViewModel>();
    }
}
