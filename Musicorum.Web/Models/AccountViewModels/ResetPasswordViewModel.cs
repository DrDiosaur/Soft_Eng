using System.ComponentModel.DataAnnotations;

namespace Musicorum.Web.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Будь-ласка введіть Ваш email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Будь-ласка введіть пароль")]
        [StringLength(100, ErrorMessage = "{0} повинен бути щонайменш {2} та не більше {1} символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Пароль та підтвердження паролю не співпадають")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
