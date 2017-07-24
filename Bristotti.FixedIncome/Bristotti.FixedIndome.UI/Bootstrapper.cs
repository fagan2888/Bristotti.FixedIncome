using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Bristotti.FixedIndome.UI.Services;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bristotti.FixedIndome.UI
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var container = new WindsorContainer();
            container.Install(
                new ServicesInstaller());

            Container = container;
        }

        public static WindsorContainer Container { get; private set; }
    }

    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .AddFacility<WcfFacility>()
                .Register(Component.For<IAssetService>().AsWcfClient(
                    WcfEndpoint
                        .BoundTo(new WSHttpBinding())
                        .At("http://localhost/MyServices/Asset")));
        }
    }
}
