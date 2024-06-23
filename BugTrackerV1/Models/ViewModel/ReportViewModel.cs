namespace BugTrackerV1.Models.ViewModel
{
    public class ReportViewModel
    {
        public int IssueCount {  get; set; }
        public int OpenIssueCount {  get; set; }
        public int ClosedIssueCount { get; set; }
        public int InProgressIssueCount { get; set; }
        public Dictionary<string,int> IssuesBySprint { get; set; }
        public Dictionary<string, int> IssuesByUser {  get; set; }
        public Dictionary<string, int> IssuesByProject { get; set; } 
    }
}
