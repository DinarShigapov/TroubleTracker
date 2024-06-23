namespace BugTrackerV1.Models
{
    public class IssuePriority
    {
        public IssuePriority()
        {
            this.Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string NamePriority { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }
    }


}
