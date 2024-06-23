using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel
{
    public class RegistViewModel
    {
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }    
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }    
        [Required(ErrorMessage = "Введите отчество")]

        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}
