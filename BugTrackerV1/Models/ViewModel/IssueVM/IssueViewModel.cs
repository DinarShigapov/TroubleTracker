using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTrackerV1.Models.ViewModel.IssueVM
{
    public class IssueViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string PriorityImage { get; set; }
        public string Status { get; set; }
        public UserViewModel CreatedBy { get; set; }
        public UserViewModel? AssignedTo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<FileViewModel> Attachment = new List<FileViewModel>();
    }
}
