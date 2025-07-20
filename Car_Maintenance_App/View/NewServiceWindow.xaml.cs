using Car_Maintenance_App.Model;
using Car_Maintenance_App.Services;
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
    /// Interaction logic for NewServiceWindow.xaml
    /// </summary>
    public partial class NewServiceWindow : Window
    {
        public NewServiceWindow()
        {
            InitializeComponent();
        }

        private void ServiceTypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceTypeComboBox.ItemsSource = Enum.GetValues(typeof(ServiceType)).Cast<ServiceType>();
            ServiceTypeComboBox.SelectedIndex = 0; // Optional: set default selection
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            var selectedServiceType = (ServiceType)ServiceTypeComboBox.SelectedItem;
            var description = DescriptionBox.Text;
            var vin = vinBox.Text;

            Car carId = CarService.GetCarByVin(vin);

            if (carId == null)
            {
                MessageBox.Show("Car with the provided VIN does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Call your service to create the service
                ServiceService.CreateService(
                    carId: carId.Id,
                    userId: 0, // Assuming a default user ID for now
                    type: selectedServiceType,
                    description: description
                );
                MessageBox.Show("Service saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // close the window after successful save
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the service: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
