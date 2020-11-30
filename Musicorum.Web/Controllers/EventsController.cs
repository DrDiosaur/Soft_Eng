using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musicorum.Services;
using Musicorum.Services.Classes;
using Musicorum.Services.Models;
using Musicorum.Web.Extensions;
using Musicorum.Web.Infrastructure.Filters;
using Musicorum.Web.Models.Events;
using System.Collections.Generic;

namespace Musicorum.Web.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        private const int eventsTake = 4;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult Index()
        {
            IList<EventModel> events = this.eventService.GetEventsOfTake(0, eventsTake);
            long eventsShown = events.Count;
            long eventsCount = this.eventService.CountAllEvents();
            
            EventsPageModel model = new EventsPageModel
            {
                Skip = eventsTake,
                HasMore = eventsCount > eventsShown,
                Events = events,
            };

            return View(model);
        }

        public IActionResult AddEvent()
        {
            return PartialView("_CreateEvent");
        }

        [HttpPost]
        public IActionResult AddEvent(EventFormModel model)
        {
            this.eventService.Create(
                model.ImageUrl,
                model.Title,
                model.Location,
                model.Description,
                model.DateStarts,
                model.DateEnds,
                model.Photos,
                model.Videos);

            return RedirectToAction("Index", "Admin", new { categoryId = 4 });
        }

        [HttpGet]
        public IActionResult EditEvent(int eventId)
        {
            EventModel ev = this.eventService.EventById(eventId);

            EventFormModel model = new EventFormModel
            {
                EventId = ev.Id,
                ImageUrl = ev.ImageUrl,
                Title = ev.Title,
                Location = ev.Location,
                Description = ev.Description,
                DateEnds = ev.DateEnds,
                DateStarts = ev.DateStarts,
            };

            return PartialView("_EditEvent", model);
        }

        [HttpPost]
        public IActionResult EditEvent(EventFormModel model)
        {
            this.eventService.Edit(
                model.EventId,
                model.ImageUrl,
                model.Title,
                model.Location,
                model.Description,
                model.DateStarts,
                model.DateEnds,
                model.Photos,
                model.Videos);

            return RedirectToAction("Index", "Admin", new { categoryId = 4 });
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int eventId)
        {
            this.eventService.Delete(eventId);

            return Json(new { message = "Успішно видалено" });
        }

        [HttpGet]
        public IActionResult GetEvent(int eventId, bool reload = true)
        {
            /*if (reload)
            {
                FileHelper.ClearVideoCache();

                this.eventService.EventById(eventId);

                return RedirectToAction("GetEvent", new { eventId, reload = false});
            }
            else
            {
                EventModel ev = this.eventService.EventById(eventId);

                return View("EventPage", ev);
            }*/

            FileHelper.ClearVideoCache();

            EventModel ev = this.eventService.EventById(eventId);

            return View("EventPage", ev);
        }

        [HttpGet]
        public IActionResult GetMoreEvents(int skip)
        {
            IList<EventModel> events = this.eventService.GetEventsOfTake(skip, eventsTake);
            long eventsShown = this.eventService.GetEventsOfTake(0, skip + eventsTake).Count;
            long eventsCount = this.eventService.CountAllEvents();

            EventsPageModel model = new EventsPageModel
            {
                Skip = skip + eventsTake,
                HasMore = eventsCount > eventsShown,
                Events = events,
            };

            return PartialView("_EventsList", model);
        }
    }
}