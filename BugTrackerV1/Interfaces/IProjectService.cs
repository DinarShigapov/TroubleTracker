using BugTrackerV1.Models;

namespace BugTrackerV1.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetProjectsForUser(int userid);
        void SetSelectedProject(int projectId, HttpContext context);
        int? GetSelectedProject(HttpContext context);
    }
}
