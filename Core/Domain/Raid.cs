using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Raid : Entity
    {
        public Raid()
        {
            Entries = new Collection<Entry>();
        }
        public string Name { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
