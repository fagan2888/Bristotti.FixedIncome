using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bristotti.FixedIndome.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bootstrapper.Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var service = Bootstrapper.Container.Resolve<Services.IAssetService>();
            var asset = service.GetByTicker("ASSET068");

            asset.Notional -= 1e6m;
            service.IsValid(asset);

            ((ICommunicationObject) service).Close();
        }
    }
}
