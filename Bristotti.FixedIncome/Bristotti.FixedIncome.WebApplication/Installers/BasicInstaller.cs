using System;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bristotti.FixedIncome.WebApplication.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .AddFacility<WcfFacility>()
                .Register(Component.For<IAssetService>()
                    .ImplementedBy<AssetService>()
                    .AsWcfService()
                    .LifestylePerWcfOperation());
        }
    }
}