using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.RoleVM
{
    public class CreateRoleViewModel
    {
        [Required]
        public string NameRole { get; set; }
        public string? Description { get; set; }
    }
}
