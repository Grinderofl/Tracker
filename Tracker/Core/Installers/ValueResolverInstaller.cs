using System;
using System.Reflection;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tracker.Core.Extensions;

namespace Tracker.Core.Installers
{
    public class ValueResolverInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var registrar = container.Resolve<AssemblyRegistrar>();
            Action<Assembly> action =
                asm => container.Register(Types.FromAssembly(asm).BasedOn<IValueResolver>().WithServiceSelf());
            Action<Assembly> concreteAction =
                asm => container.Register(Types.FromAssembly(asm).BasedOn(typeof (ValueResolver<,>)).WithServiceSelf());
            action.VisitAssemblies(registrar);
            concreteAction.VisitAssemblies(registrar);
        }
    }
}