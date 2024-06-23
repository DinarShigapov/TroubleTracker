namespace BugTrackerV1.Models.ViewModel.KanbanVM
{
    public class KanbanColumnViewModel
    {
        public int StatusId { get; set; }
        public string NameStatus { get; set; }
        public List<KanbanCardViewModel> Cards { get; set; }
    }
}
