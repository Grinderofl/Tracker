using Core.Domain;

namespace Tracker.Features.Attendances.Models
{
    public class AttendancesEditViewModel
    {
        public long AttendanceId { get; set; }
        public long RaidId { get; set; }
        public Entry[] Entries { get; set; }
    }
}