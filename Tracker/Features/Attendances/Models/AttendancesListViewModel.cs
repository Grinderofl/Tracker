using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Domain;

namespace Tracker.Features.Attendances.Models
{
    public class AttendancesListViewModel
    {
        public AttendancesListViewModel()
        {
            Filter = new List<AttendancesFilterModel>();
        }
        public IEnumerable<AttendanceListItem> Attendance { get; set; }
        public IList<AttendancesFilterModel> Filter { get; set; }
    }

    public class AttendanceListItem
    {
        public AttendanceListItem()
        {
            Attendances = new List<double>();
        }
        public long CharacterId { get; set; }
        public string Character { get; set; }
        public ICollection<double> Attendances { get; set; }
    }
}