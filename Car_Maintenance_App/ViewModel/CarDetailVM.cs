using Car_Maintenance_App.Model;
using Car_Maintenance_App.Services;
using Car_Maintenance_App.ViewModel.Commands;
using Car_Maintenance_App.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Car_Maintenance_App.ViewModel
{
    public class CarDetailVM
    {
        public Car Car { get; set; }
        public List<Service> Services { get; set; }
        public List<CarStatus> StatusOptions { get; } =
            Enum.GetValues(typeof(CarStatus)).Cast<CarStatus>().ToList();

        public CarStatus Status { get; set; }

        public UpdateCarCommand UpdateCarCommand { get; set; }

        public CarDetailVM(Car car)
        {
            Car = car;
            Services = DatabaseHelper.Read<Service>().Where(s => s.CarId == car.Id).ToList();

            UpdateCarCommand = new UpdateCarCommand(this);
        }

        public void UpdateCar()
        {
            CarService.UpdateCar(
                Car.Id,
                Car.VIN,
                Car.LicensePlate,
                Car.Make,
                Car.Model,
                Car.Color,
                Car.Year,
                Car.Mileage,
                Car.Status
            );
        }
    }
}
