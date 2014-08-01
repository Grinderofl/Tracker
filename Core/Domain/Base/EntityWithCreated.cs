﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Base
{
    public abstract class EntityWithCreated : Entity
    {
        public DateTime Created { get; set; }
    }
}
