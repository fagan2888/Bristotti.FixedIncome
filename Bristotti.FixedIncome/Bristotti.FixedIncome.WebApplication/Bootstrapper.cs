using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Bristotti.FixedIncome.DataAccess;
using Bristotti.FixedIncome.Model;
using Bristotti.FixedIncome.WebApplication.Installers;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Bristotti.FixedIncome.WebApplication
{
    public class Bootstrapper
    {

        public static void Initialize()
        {
            var cfg = new Configuration()
                .DataBaseIntegration(db =>
                {
                    db.ConnectionString =
                        @"Data Source=(localdb)\ProjectsV13;Initial Catalog=fi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    db.Dialect<MsSql2012Dialect>();
                });

            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(AssetMapping).Assembly.GetExportedTypes());
            cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
            SessionFactory = cfg.BuildSessionFactory();

            new SchemaExport(cfg).Execute(true, true, false);

            LoadInitialData();

            var container = new WindsorContainer();
            container.Install(
                new HibernateInstaller(),
                new ServicesInstaller());

            Container = container;
        }

        private static void LoadInitialData()
        {
            using (var session = SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                for (var i = 0; i < 100; i++)
                {
                    session.Save(new Asset
                    {
                        Ticker = $"ASSET{i:000}",
                        IssueDate = DateTime.Today.AddDays(i),
                        MaturityDate = DateTime.Today.AddDays(i),
                        Notional = i*1e6m,
                        CurrencyId = "BRL"
                    });
                }

                tx.Commit();
            }
        }

        public static WindsorContainer Container { get; private set; }

        public static ISessionFactory SessionFactory { get; private set; }
    }
}