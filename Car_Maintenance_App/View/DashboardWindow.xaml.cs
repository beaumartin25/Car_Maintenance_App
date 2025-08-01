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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }
        private void newCarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewCarWindow newCarWindow = new NewCarWindow();
            newCarWindow.Owner = this;
            newCarWindow.ShowDialog();
        }

        private void newServiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewServiceWindow newServiceWindow = new NewServiceWindow();
            newServiceWindow.Owner = this;
            newServiceWindow.ShowDialog();
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var car = button?.DataContext as Car;
            if (car == null) return;

            CarDetailWindow detailWindow = new CarDetailWindow(car);
            bool? result = detailWindow.ShowDialog();
        }
    }
}
