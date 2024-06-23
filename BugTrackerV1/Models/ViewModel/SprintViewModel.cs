using BugTrackerV1.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel
{
    public class SprintViewModel
    {
        [Required(ErrorMessage = "Введите название спринта.")]
        public string NameSprint { get; set; }

        [Required(ErrorMessage = "Введите дату начала спринта.")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала")]
        [FutureDate(ErrorMessage = "Дата начала спринта не может быть ранее сегодняшнего дня.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Введите дату окончания спринта.")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания")]
        public DateTime EndDate { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult("Дата окончания спринта должна быть позже даты начала.", new[] { "EndDate" });
            }
        }
    }
}
