namespace BugTrackerV1.Interfaces
{
    public interface IPermissionService
    {
        Task<List<string>> GetUserPermissionsAsync(int userId);
    }
}
