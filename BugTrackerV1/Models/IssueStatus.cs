namespace BugTrackerV1.Models
{
    public class IssueStatus
    {
        public IssueStatus()
        {
            this.Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string NameStatus { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }
    }


}
