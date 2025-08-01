using Car_Maintenance_App.Model;
using Car_Maintenance_App.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.ViewModel
{
    class CarDetailVM
    {
        public Car Car { get; set; }
        public List<Service> Services { get; set; }
        public CarDetailVM(Car car)
        {
            Car = car;
            Services = DatabaseHelper.Read<Service>().Where(s => s.CarId == car.Id).ToList();
        }
    }
}
