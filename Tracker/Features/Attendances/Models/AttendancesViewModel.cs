using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Features.Attendances.Models
{
    public class AttendancesViewModel
    {
        public AttendanceEntry[] Entries { get; set; }
    }

    public class AttendanceEntry
    {
        public string Character { get; set; }
        public double Past30Days { get; set; }
        public double Past2Weeks { get; set; }
        public double PastWeek { get; set; }
        public double Total { get; set; }
    }
}