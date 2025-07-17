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
using Car_Maintenance_App.Services;


namespace Car_Maintenance_App.View
{
    /// <summary>
    /// Interaction logic for NewCarWindow.xaml
    /// </summary>
    public partial class NewCarWindow : Window
    {
        public NewCarWindow()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse numeric fields safely
                if (!int.TryParse(yearBox.Text, out int year))
                {
                    MessageBox.Show("Please enter a valid year.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(mileageBox.Text, out int mileage))
                {
                    MessageBox.Show("Please enter a valid mileage.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Call your service to create the car
                CarService.CreateCar(
                    vin: vinBox.Text,
                    licensePlate:licensePlateBox.Text,
                    make: makeBox.Text,
                    model: modelBox.Text,
                    color: colorBox.Text,
                    year: year,
                    mileage: mileage
                );

                MessageBox.Show("Car saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // close the window after successful save
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the car: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
