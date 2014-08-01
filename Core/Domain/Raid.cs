using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Raid : Entity
    {
        public string Name { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
