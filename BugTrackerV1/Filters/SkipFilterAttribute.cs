using Microsoft.AspNetCore.Mvc.Filters;

namespace BugTrackerV1.Filters
{
    public class SkipFilterAttribute : Attribute, IFilterMetadata { }
}
