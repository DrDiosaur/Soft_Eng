using System.ComponentModel.DataAnnotations;

namespace Musicorum.Web.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Введіть будь-ласка Ваш email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
