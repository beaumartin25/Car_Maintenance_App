using Car_Maintenance_App.Model;
using Car_Maintenance_App.Services;
using Car_Maintenance_App.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.ViewModel
{
    public class DashboardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Car> CarsNeedingService { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public DashboardVM()
        {
            CarsNeedingService = new ObservableCollection<Car>();

            GetCarsNeedingService();
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
    }
}
