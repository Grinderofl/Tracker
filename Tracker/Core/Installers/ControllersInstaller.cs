using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Tracker.Core.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Types.FromAssemblyContaining<ControllersInstaller>()
                    .Pick()
                    .If(x => x.Name.EndsWith("Controller"))
                    .Configure(x => x.Named(x.Implementation.Name)));
        }
    }
}