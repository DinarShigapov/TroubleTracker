using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.PermissionVM
{
    public class PermissionViewModel
    {
        public List<RolePermissionViewModel> Roles { get; set; }
        public List<UserPermissionViewModel> Users { get; set; }
        public List<SelectListItem> AllRoles { get; set; }
        public List<SelectListItem> AllUsers { get; set; }

    }
}
