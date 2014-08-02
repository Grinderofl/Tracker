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
    public class ProfileInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mapper.Initialize(x =>
            {
                GetAutoMapperConfiguration(Mapper.Configuration, container);
                x.ConstructServicesUsing(type => container.Resolve(type));
                x.AllowNullDestinationValues = false;
            });
        }

        private void GetAutoMapperConfiguration(IConfiguration configuration, IWindsorContainer container)
        {
            var registrar = container.Resolve<AssemblyRegistrar>();
            using (var childContainer = new WindsorContainer())
            {
                Action<Assembly> action =
                    asm =>
                        childContainer.Register(Types.FromAssembly(asm)
                            .BasedOn<Profile>()
                            .WithServices(typeof(Profile)));
                action.VisitAssemblies(registrar);

                foreach (var profile in childContainer.ResolveAll<Profile>())
                    configuration.AddProfile(profile);
            }
        }
    }

}