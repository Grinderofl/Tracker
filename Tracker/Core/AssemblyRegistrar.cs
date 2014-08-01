using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Tracker.Core
{
    public class AssemblyRegistrar
    {
        public AssemblyRegistrar()
        {
            _assemblies = new List<Assembly>();
        }
        private readonly List<Assembly> _assemblies;

        public IEnumerable<Assembly> Assemblies
        {
            get { return _assemblies; }
        }

        public AssemblyRegistrar AddAssemblyContaining<TClass>()
        {
            var assembly = typeof (TClass).Assembly;
            if(!_assemblies.Contains(assembly))
                _assemblies.Add(assembly);

            return this;
        }

    }
}