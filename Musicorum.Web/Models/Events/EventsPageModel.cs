using Musicorum.Services.Models;
using System.Collections.Generic;

namespace Musicorum.Web.Models.Events
{
    public class EventsPageModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public IList<EventModel> Events { get; set; }
        public bool HasMore { get; set; }
    }
}
