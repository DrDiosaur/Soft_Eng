using System.ComponentModel.DataAnnotations;

namespace Musicorum.Web.Models.HomeViewModels
{
    public class EmailModel
    {
        [Required(ErrorMessage = "Вкажіть своє ім'я будь-ласка")]
        [StringLength(50)]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вкажіть свій email будь-ласка")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть тему будь-ласка")]
        [StringLength(50)]
        [Display(Name = "Тема")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Вкажіть своє повідомлення будь-ласка")]
        [Display(Name = "Повідомлення")]
        public string Message { get; set; }
    }
}