using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Features.Attendances.Models
{
    public class AttendancesFilterModel
    {
        public bool Add { get; set; }
        public bool Delete { get; set; }
        public string Sort { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}