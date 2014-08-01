using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor.Installer;

namespace Tracker.Core.Windsor
{
    public class PriorityInstallerFactory : InstallerFactory
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            return installerTypes.OrderBy(x => GetPriority(x));
        }

        private int GetPriority(Type type)
        {
            var attribute =
                type.GetCustomAttributes(typeof (InstallerPriorityAttribute), false).FirstOrDefault() as
                    InstallerPriorityAttribute;
            return attribute != null ? attribute.Priority : InstallerPriorityAttribute.DefaultPriority;
        }
    }
}