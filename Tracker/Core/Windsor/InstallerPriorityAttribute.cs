﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Core.Windsor
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class InstallerPriorityAttribute : Attribute
    {
        public const int DefaultPriority = 100;

        public int Priority { get; private set; }

        public InstallerPriorityAttribute(int priority)
        {
            Priority = priority;
        }
    }
}