using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tracker.Core.Extensions;

namespace Tracker.Core.Installers
{
    public class MappingActionsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var registrar = container.Resolve<AssemblyRegistrar>();
            Action<Assembly> action =
                asm => container.Register(Types.FromAssembly(asm).BasedOn(typeof(IMappingAction<,>)).WithServiceSelf());
            action.VisitAssemblies(registrar);
        }
    }
}