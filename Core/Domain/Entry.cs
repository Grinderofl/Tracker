using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Entry : EntityWithCreated
    {
        public Entry()
        {
            Attendances = new Collection<Attendance>();
        }
        public Raid Raid { get; set; }
        public DateTime RaidDate { get; set; }
        public ApplicationUser Author { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
