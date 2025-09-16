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
    /// Interaction logic for CarDetailWindow.xaml
    /// </summary>
    public partial class CarDetailWindow : Window
    {
        public CarDetailWindow(Car car)
        {
            InitializeComponent();
            DataContext = new CarDetailVM(car);
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var service = button?.DataContext as Service;
            if (service == null) return;

            ServiceDetailWindow detailWindow = new ServiceDetailWindow(service);
            bool? result = detailWindow.ShowDialog();
        }
    }
}
