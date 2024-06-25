using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.ProjectVM
{
    public class CreateProjectViewModel
    {
        [Required(ErrorMessage = "Не указано название")]
        [MinLength(2, ErrorMessage = "Название проекта должен содержать минимум 2 символа.")]
        [MaxLength(50, ErrorMessage = "Название проекта должен содержать максимум 50 символов.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Не указан ключ")]
        [MinLength(2, ErrorMessage = "Ключ проекта должен содержать минимум 2 символа.")]
        [MaxLength(10, ErrorMessage = "Ключ проекта должен содержать максимум 10 символов.")]
        [RegularExpression("^[A-Z][A-Z0-9]*$", ErrorMessage = "Ключ проекта должен начинаться с большой буквы, за которой следует одна или несколько цифр или букв в верхнем регистре.")]
        public string Key { get; set; }

    }
}
