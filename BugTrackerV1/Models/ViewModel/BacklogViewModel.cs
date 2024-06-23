

namespace BugTrackerV1.Models.ViewModel
{
    public class BacklogViewModel
    {
        public Sprint? ActiveSprint { get; set; }
        public List<Sprint> FutureSprints { get; set; }
        public List<Models.Issue> BacklogTasks { get; set; }
    }
}
