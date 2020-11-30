using Microsoft.AspNetCore.Mvc;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using Musicorum.Services;
using Musicorum.Web.Infrastructure;
using Musicorum.Web.Infrastructure.Filters;
using Musicorum.Web.Models;
using Musicorum.Web.Models.HomeViewModels;
using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using Musicorum.Services.Models;
using Musicorum.Web.Extensions;
using Musicorum.Services.Classes;

namespace Musicorum.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int songsTake = 10;
        private const int eventsTake = 5;

        private readonly IEmailSender emailSender;
        private readonly INewsService newsService;
        private readonly ISongService songService;
        private readonly IEventService eventService;

        public HomeController(IEmailSender emailSender, INewsService newsService, ISongService songService, IEventService eventService)
        {
            this.emailSender = emailSender;
            this.newsService = newsService;
            this.songService = songService;
            this.eventService = eventService;
        }

        public IActionResult Index()
        {
            IList<NewsModel> news = this.newsService.GetAllFavorites();
            IList<SongModel> songs = this.songService.GetSongsWithTake(User.GetUserId(), 0, songsTake);
            IList<EventModel> events = this.eventService.GetEventsOfTake(0, eventsTake);

            HomePageModel model = new HomePageModel
            {
                News = news,
                Songs = songs,
                Events = events,
            };


            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Зворотній зв'язок.";

            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Contact(EmailModel model)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Від: {model.Name} {model.Email}");
            message.AppendLine();
            message.AppendLine(model.Message);

            try
            {
                this.emailSender.SendEmailAsync(GlobalConstants.MusicorumEmail, model.Subject, message.ToString());
                ViewData["SuccessMessage"] = "Ваш email був успішно надісланий!";
                return View(model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("EmailSenderror", "Щось пішло не так, спробуйте ще раз!");
                return View(model);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}