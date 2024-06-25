using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.PermissionVM
{
    public class RolePermissionViewModel
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        [Display(Name = "Permissions")]
        public List<PermissionCheckboxViewModel> Permissions { get; set; }
    }
}
