using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Base
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime Modified { get; set; }
    }
}
