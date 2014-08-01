using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Tracker.Core.Extensions
{
    public static class AssemblyRegistrarExtensions
    {
        public static void VisitAssemblies(this Action<Assembly> action, AssemblyRegistrar registrar)
        {
            foreach (var assembly in registrar.Assemblies)
                action(assembly);
        }
    }
}