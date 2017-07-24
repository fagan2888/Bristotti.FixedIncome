using System;
using Bristotti.FixedIncome.DataAccess.Repositories;
using Bristotti.FixedIncome.Model.Repositories;
using Bristotti.FixedIncome.Model.Services;
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
                .AddFacility<WcfFacility>();

            container
                .Register(Component.For<IAssetService>()
                    .ImplementedBy<AssetService>()
                    .Named("AssetService"));

            container
                .Register(Component.For<IAssetRepository>()
                    .ImplementedBy<AssetRepository>());
        }
    }
}