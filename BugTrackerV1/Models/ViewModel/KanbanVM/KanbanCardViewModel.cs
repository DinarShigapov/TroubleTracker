namespace BugTrackerV1.Models.ViewModel.KanbanVM
{
    public class KanbanCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string PriorityImage { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Type { get; set; }
        public string TypeImage { get; set; }
        public List<string> Labels { get; set; }
    }
}
