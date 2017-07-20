using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bristotti.FixedIncome.WebApplication.Installers;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;

namespace Bristotti.FixedIncome.WebApplication
{
    public class Bootstrapper
    {

        public static void Initialize()
        {
            var cfg = new Configuration();
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