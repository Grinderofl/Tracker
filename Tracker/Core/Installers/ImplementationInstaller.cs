using System;
using System.Reflection;
using Antlr.Runtime.Misc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tracker.Core.Extensions;

namespace Tracker.Core.Installers
{
    public class ImplementationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var registrar = container.Resolve<AssemblyRegistrar>();
            Action<Assembly> action =
                asm =>
                    container.Register(
                        Classes.FromAssembly(asm).Pick()
                            .If(
                                x =>
                                    x.Namespace != null &&
                                    x.Namespace.EndsWith("Impl", StringComparison.OrdinalIgnoreCase))
                            .LifestylePerWebRequest()
                            .WithServiceAllInterfaces());
            action.VisitAssemblies(registrar);
        }
    }
}