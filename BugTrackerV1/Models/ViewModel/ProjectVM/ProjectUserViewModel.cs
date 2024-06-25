using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerV1.Models.ViewModel.ProjectVM
{
    public class ProjectUserViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Не указан ключ")]
        [MinLength(2, ErrorMessage = "Ключ проекта должен содержать минимум 2 символа.")]
        [MaxLength(10, ErrorMessage = "Ключ проекта должен содержать максимум 10 символов.")]
        [RegularExpression("^[A-Z][A-Z0-9]*$", ErrorMessage = "Ключ проекта должен начинаться с большой буквы, за которой следует одна или несколько цифр или букв в верхнем регистре.")]
        public string ProjectKey { get; set; }
        public string? ProjectDescription { get; set; }
        public List<int> SelectedUserIds { get; set; }
        public List<SelectListItem> UsersInProject { get; set; }
        public List<SelectListItem> UsersOutOfProject { get; set; }
    }
}
