using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Core.Domain;

namespace Tracker.Core.Installers
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<AssemblyRegistrar>().LifestyleSingleton());
            var registrar = container.Resolve<AssemblyRegistrar>();
            registrar.AddAssemblyContaining<ApplicationUser>().AddAssemblyContaining<CoreInstaller>();
        }
    }
}