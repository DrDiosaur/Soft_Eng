using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musicorum.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Логін")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required(ErrorMessage = "Email не введено")]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
