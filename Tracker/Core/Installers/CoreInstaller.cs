using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Core.Domain;
using Tracker.Core.Windsor;

namespace Tracker.Core.Installers
{
    [InstallerPriority(0)]
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