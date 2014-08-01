using System;

namespace Tracker.Features.Events.Models
{
    public class EventListItem
    {
        public long Id { get; set; }
        public string Raid { get; set; }
        public int Participants { get; set; }
        public DateTime RaidDate { get; set; }
    }
}