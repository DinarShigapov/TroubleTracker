namespace BugTrackerV1.Models
{
    public class Label
    {
        public Label()
        {
            this.LabelIssue = new HashSet<LabelIssue>();
        }

        public int Id { get; set; }
        public string NameLabel { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<LabelIssue> LabelIssue { get; set; }
    }


}
