namespace BugTrackerV1.Models
{
    public class UserPermissions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public virtual User User { get; set; }
        public virtual Permission Permission { get; set; }
    }


}
