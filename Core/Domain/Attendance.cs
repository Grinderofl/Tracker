using Core.Domain.Base;

namespace Core.Domain
{
    public class Attendance : Entity
    {
        public Character Attendee { get; set; }
        public Entry Entry { get; set; }
        public bool HasAfkPost { get; set; }
        public bool IsLate { get; set; }
        public bool HasAttended { get; set; }
    }
}