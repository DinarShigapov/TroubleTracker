namespace BugTrackerV1.Models
{
    public class IssueHistory
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string ModifiedElement { get; set; }
        public string OldVersion { get; set; }
        public string NewVersion { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Issue Issue { get; set; }
    }


}
