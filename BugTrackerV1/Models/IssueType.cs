namespace BugTrackerV1.Models
{
    public class IssueType
    {
        public IssueType()
        {
            this.Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string NameType { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }
    }
}
