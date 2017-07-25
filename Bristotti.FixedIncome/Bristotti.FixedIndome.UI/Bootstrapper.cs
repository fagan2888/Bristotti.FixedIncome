using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
