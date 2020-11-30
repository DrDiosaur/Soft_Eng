using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Musicorum.Web.Services;
using Musicorum.Services;

namespace Musicorum.Web.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Підтвердіть Ваш email",
                $"Будь-ласка відновіть свій пароль натиснувши сюди: <a href='{HtmlEncoder.Default.Encode(link)}'>посилання</a>");
        }
    }
}
