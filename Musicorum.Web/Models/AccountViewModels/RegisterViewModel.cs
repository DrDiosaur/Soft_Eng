using Microsoft.AspNetCore.Http;
using Musicorum.Web.Infrastructure.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Musicorum.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть будь-ласка Ваш email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка Ваше ім'я")]
        [Display(Name = "Ім'я")]
        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка Ваше прізвище")]
        [Display(Name = "Прізвище")]
        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка логін")]
        [Display(Name = "Логін")]
        [MinLength(2), MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка Ваш вік")]
        [Age]
        [Display(Name = "Вік")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка пароль")]
        [StringLength(100, ErrorMessage = "{0} повинен бути щонайменш {2} та не більше ніж {1} символів.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        [Compare("Password", ErrorMessage = "Пароль та підтведження паролю не співпадають.")]
        public string ConfirmPassword { get; set; }
    }
}