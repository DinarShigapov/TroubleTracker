namespace BugTrackerV1.Models
{
    public class LabelIssue
    {
        public int Id { get; set; }
        public int LabelId { get; set; }
        public int IssueId { get; set; }

        public virtual Label Label { get; set; }
        public virtual Issue Issue { get; set; }
    }


}
