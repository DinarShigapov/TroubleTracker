﻿namespace BugTrackerV1.Models
{
    public class ProjectUsers
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
