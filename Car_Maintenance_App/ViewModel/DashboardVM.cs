using Car_Maintenance_App.Model;
using Car_Maintenance_App.Services;
using Car_Maintenance_App.ViewModel.Commands;
using Car_Maintenance_App.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.ViewModel
{
    public class DashboardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler SelectedCarChanged;

        private Car selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (selectedCar != value)
                {
                    selectedCar = value;
                    OnPropertyChanged("SelectedCar");
                    SelectedCarChanged?.Invoke(this, EventArgs.Empty);
                    Services = DatabaseHelper.Read<Service>().Where(s => s.CarId == selectedCar.Id).ToList();
                    OnPropertyChanged("Services");
                }
            }
        }
        public List<Service> Services { get; set; }
        public List<CarStatus> StatusOptions { get; } =
            Enum.GetValues(typeof(CarStatus)).Cast<CarStatus>().ToList();
        public ObservableCollection<Car> CarsNeedingService { get; set; }

        public UpdateCarCommand UpdateCarCommand { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public DashboardVM()
        {
            CarsNeedingService = new ObservableCollection<Car>();

            GetCarsNeedingService();

            UpdateCarCommand = new UpdateCarCommand(this);

        }

        public void GetCarsNeedingService()
        {
            CarsNeedingService.Clear();

            var carsNeedingService = CarService.GetCarsNeedingService();

            foreach (var car in carsNeedingService)
            {
                CarsNeedingService.Add(car);
            }
        }
        
        public void CreateCar(string vin, string licensePlate, string make, string model, string color, int year, int mileage)
        {
            CarService.CreateCar(vin, licensePlate, make, model, color, year, mileage);
            GetCarsNeedingService();
        }

        public void UpdateCar()
        {
            CarService.UpdateCar(
                SelectedCar.Id,
                SelectedCar.VIN,
                SelectedCar.LicensePlate,
                SelectedCar.Make,
                SelectedCar.Model,
                SelectedCar.Color,
                SelectedCar.Year,
                SelectedCar.Mileage,
                SelectedCar.Status
            );
        }
    }
}
