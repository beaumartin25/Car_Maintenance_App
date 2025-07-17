using Car_Maintenance_App.Model;
using Car_Maintenance_App.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.Services
{
    public class CarService
    {
        public static void CreateCar(string vin, string licensePlate, string make, string model, string color, int year, int mileage)
        {
            // Logic to create a new car record
            Car newCar = new Car
            {
                VIN = vin,
                LicensePlate = licensePlate,
                Make = make,
                Model = model,
                Color = color,
                Year = year,
                Mileage = mileage,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            DatabaseHelper.Insert(newCar);
        }
        public static void UpdateCar(int id, string vin, string licensePlate, string make, string model, string color, int year, int mileage)
        {
            // Logic to update an existing car record
            Car carToUpdate = new Car
            {
                Id = id,
                VIN = vin,
                LicensePlate = licensePlate,
                Make = make,
                Model = model,
                Color = color,
                Year = year,
                Mileage = mileage,
                UpdatedAt = DateTime.Now
            };

            DatabaseHelper.Update(carToUpdate);
        }
        public static void DeleteCar(int id)
        {
            // Logic to delete a car record
            DatabaseHelper.Delete(new Car { Id = id });
        }
        public static List<Car> GetAllCars()
        {
            // Logic to retrieve all car records
            return DatabaseHelper.Read<Car>().ToList();
        }

        public static List<Car> GetCarsNeedingService()
        {
            var allCars = DatabaseHelper.Read<Car>().ToList();
            var incompleteServices = DatabaseHelper.Read<Service>()
                                                   .Where(s => s.Status != "Completed")
                                                   .ToList();

            var needingService = from service in incompleteServices
                                 join car in allCars on service.CarId equals car.Id
                                 select car;

            return needingService.Distinct().ToList();
        }
    }
}
