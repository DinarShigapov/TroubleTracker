namespace BugTrackerV1.Models
{
    public class Issue
    {
        public Issue()
        {
            this.IssueAttachment = new HashSet<IssueAttachment>();
            this.IssueComment = new HashSet<IssueComment>();
            this.IssueHistory = new HashSet<IssueHistory>();
            this.LabelIssue = new HashSet<LabelIssue>();
            this.StepsToReproduce = new HashSet<StepsToReproduce>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int? AssignedToId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? SprintId { get; set; }
        public int ProjectId { get; set; }
        public int CreatedById { get; set; }

        public virtual IssuePriority Priority { get; set; }
        public virtual IssueStatus Status { get; set; }
        public virtual IssueType Type { get; set; }
        public virtual User AssignedTo { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual Sprint? Sprint { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<IssueAttachment> IssueAttachment { get; set; }
        public virtual ICollection<IssueComment> IssueComment { get; set; }
        public virtual ICollection<IssueHistory> IssueHistory { get; set; }
        public virtual ICollection<LabelIssue> LabelIssue { get; set; }
        public virtual ICollection<StepsToReproduce> StepsToReproduce { get; set; }
    }


}
