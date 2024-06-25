namespace BugTrackerV1.Models
{
    public class User
    {
        public User()
        {
            this.AssignedIssues = new HashSet<Issue>();
            this.CreatedIssues = new HashSet<Issue>();
            this.Project = new HashSet<Project>();
            this.IssueAttachment = new HashSet<IssueAttachment>();
            this.IssueComment = new HashSet<IssueComment>();
            this.Label = new HashSet<Label>();
            this.UserRoles = new HashSet<UserRoles>();
            this.ProjectUsers = new HashSet<ProjectUsers>();
            this.UserPermissions = new HashSet<UserPermissions>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Phone { get; set; }

        public string ShortNameUser 
        {
            get 
            {
                return $"{LastName} {FirstName.ToCharArray()[0]}. {Patronymic.ToCharArray()[0]}.";
            }
        }

        public virtual ICollection<Issue> AssignedIssues { get; set; }
        public virtual ICollection<Issue> CreatedIssues { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<IssueAttachment> IssueAttachment { get; set; }
        public virtual ICollection<IssueComment> IssueComment { get; set; }
        public virtual ICollection<Label> Label { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<ProjectUsers> ProjectUsers { get; set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }


}
