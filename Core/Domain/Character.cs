﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Character : EntityWithCreated
    {
        public Character()
        {
            Attendances = new Collection<Attendance>();
        }
        public string Name { get; set; }
        public Classes Class { get; set; }
        public Races Race { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public bool Hidden { get; set; }
    }
}
