namespace BugTrackerV1.Models
{
    public class Sprint
    {
        public Sprint()
        {
            this.Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string NameSprint { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
    }


}
