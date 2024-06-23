namespace BugTrackerV1.Models
{
    public class IssueComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CommentAuthorId { get; set; }
        public int IssueId { get; set; }

        public virtual User User { get; set; }
        public virtual Issue Issue { get; set; }
    }


}
