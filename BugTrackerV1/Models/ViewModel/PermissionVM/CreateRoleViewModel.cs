using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.PermissionVM
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string NameRole { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
