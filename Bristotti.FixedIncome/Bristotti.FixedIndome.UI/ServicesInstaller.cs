using System.ServiceModel;
using Bristotti.FixedIndome.UI.Services;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bristotti.FixedIndome.UI
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .AddFacility<WcfFacility>()
                .Register(Component.For<IAssetService>().AsWcfClient(
                    WcfEndpoint
                        .BoundTo(new WSHttpBinding())
                        .At("http://localhost:3203/AssetService.svc")));
        }
    }
}