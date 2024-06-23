using Microsoft.VisualBasic;

namespace BugTrackerV1.Models
{
    public class Project
    {
        public Project()
        {
            this.Issue = new HashSet<Issue>();
            this.ProjectUsers = new HashSet<ProjectUsers>();
            this.Sprints = new HashSet<Sprint>();
        }

        public int Id { get; set; }
        public string NameProject { get; set; }
        public string KeyProject { get; set; }
        public string Description { get; set; }
        public int ProjectManagerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ActiveSprintId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
        public virtual ICollection<ProjectUsers> ProjectUsers { get; set; }
        public virtual Sprint? Sprint { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
    }


}
