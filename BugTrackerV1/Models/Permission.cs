namespace BugTrackerV1.Models
{
    public class Permission
    {
        public Permission()
        {
            this.RolePermissions = new HashSet<RolePermissions>();
            this.UserPermissions = new HashSet<UserPermissions>();
        }

        public int Id { get; set; }
        public string NamePermission { get; set; }
        public string Description { get; set; }
        public string KeyPermission { get; set; }

        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }


}
