using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Mvc;
using Tracker.Core.Installers;

namespace Tracker
{
    public static class WindsorConfig
    {
        private static IWindsorContainer _container;

        public static void Configure()
        {
            _container = new WindsorContainer().Install(FromAssembly.Containing<CoreInstaller>());
            var factory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}