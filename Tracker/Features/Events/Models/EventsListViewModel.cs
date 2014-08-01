using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Features.Events.Models
{
    public class EventsListViewModel
    {
        public IEnumerable<EventListItem> Events { get; set; }
    }
}