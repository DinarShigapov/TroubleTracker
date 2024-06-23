namespace BugTrackerV1.Models
{
    public class IssueAttachment
    {
        public IssueAttachment()
        {
        }

        public int Id { get; set; }
        public string NameAttachment { get; set; }
        public DateTime UploadedAt { get; set; }
        public int UploadedById { get; set; }
        public string Link { get; set; }
        public decimal Size { get; set; }
        public string FileFormat { get; set; }
        public int IssueId { get; set; }

        public virtual User User { get; set; }
        public virtual Issue Issue { get; set; }
    }


}
