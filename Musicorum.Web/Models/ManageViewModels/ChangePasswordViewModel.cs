using System.ComponentModel.DataAnnotations;

namespace Musicorum.Web.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Введіть будь-ласка старий пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Старий пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введіть будь-ласка новий пароль")]
        [StringLength(100, ErrorMessage = "{0} повинен бути щонайменш {2} та не більше {1} символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новий пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть новий пароль")]
        [Compare("NewPassword", ErrorMessage = "Новий пароль та підтвердження паролю не співпадають")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
