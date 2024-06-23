using BugTrackerV1.Models;
using Microsoft.AspNetCore.Identity;

namespace BugTrackerV1.Services
{
    public class HashPassword
    {

        public string GetPasswordHash(string password)
        {     
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
