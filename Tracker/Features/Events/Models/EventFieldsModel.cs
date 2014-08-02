using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tracker.Features.Events.Models
{
    public class EventFieldsModel
    {
        public EventFieldsModel()
        {
            Attendees = new List<AttendanceItem>();
        }
        public long Id { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please choose a raid")]
        public long RaidId { get; set; }

        public IEnumerable<SelectListItem> PossibleRaids { get; set; }
        public ICollection<AttendanceItem> Attendees { get; set; }
        public DateTime RaidDate { get; set; }
    }

    public class AttendanceItem
    {
        public long Id { get; set; }
        public long CharacterId { get; set; }
        public string Character { get; set; }
        public bool HasAttended { get; set; }
        public bool HasAfkPost { get; set; }
        public bool IsLate { get; set; }
    }
}