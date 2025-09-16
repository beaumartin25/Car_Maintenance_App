using Car_Maintenance_App.Model;
using Car_Maintenance_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_Maintenance_App.View
{
    /// <summary>
    /// Interaction logic for CarServiceWindow.xaml
    /// </summary>
    public partial class ServiceDetailWindow : Window
    {
        public ServiceDetailWindow(Service service)
        {
            InitializeComponent();
            DataContext = new ServiceDetailVM(service);
        }
    }
}
