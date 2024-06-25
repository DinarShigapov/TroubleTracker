namespace BugTrackerV1.Models.ViewModel.RoleVM
{
    public class AssignRoleViewModel
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
        public int SelectedUserId { get; set; }
        public int SelectedRoleId { get; set; }
    }
}
