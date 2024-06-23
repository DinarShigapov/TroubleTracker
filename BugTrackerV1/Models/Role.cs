namespace BugTrackerV1.Models
{
    public class Role
    {
        public Role()
        {
            this.UserRoles = new HashSet<UserRoles>();
            this.RolePermissions = new HashSet<RolePermissions>();
        }

        public int Id { get; set; }
        public string NameRole { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }


}
