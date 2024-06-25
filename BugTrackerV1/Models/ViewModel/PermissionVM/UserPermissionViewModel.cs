using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.PermissionVM
{
    public class UserPermissionViewModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }

        [Display(Name = "Permissions")]
        public List<PermissionCheckboxViewModel> Permissions { get; set; }
    }
}
