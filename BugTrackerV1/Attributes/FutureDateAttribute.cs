using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Attributes
{
    internal class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue >= DateTime.Today.AddDays(1);
            }
            return false;
        }
    }
}