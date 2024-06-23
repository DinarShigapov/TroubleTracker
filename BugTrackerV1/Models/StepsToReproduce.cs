namespace BugTrackerV1.Models
{
    public class StepsToReproduce
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }
        public int IssueId { get; set; }

        public virtual Issue Issue { get; set; }
    }


}
