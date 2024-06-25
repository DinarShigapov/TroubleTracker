namespace BugTrackerV1.Models.ViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int IssueId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserViewModel User { get; set; }
    }
}
