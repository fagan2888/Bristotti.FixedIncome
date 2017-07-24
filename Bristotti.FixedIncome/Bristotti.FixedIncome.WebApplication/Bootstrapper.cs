using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bristotti.FixedIncome.WebApplication.Installers;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace Bristotti.FixedIncome.WebApplication
{
    public class Bootstrapper
    {

        public static void Initialize()
        {
            var cfg = new Configuration()
                .DataBaseIntegration(db =>
                {
                    db.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=fi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    db.Dialect<MsSql2012Dialect>();
                });

            cfg.AddAssembly(typeof(AssetService).Assembly);
            SessionFactory = cfg.BuildSessionFactory();

        var container = new WindsorContainer();
            container.Install(
                new HibernateInstaller(),
                new ServicesInstaller());

            Container = container;
        }

        public static WindsorContainer Container { get; private set; }

        public static ISessionFactory SessionFactory { get; private set; }
    }
}