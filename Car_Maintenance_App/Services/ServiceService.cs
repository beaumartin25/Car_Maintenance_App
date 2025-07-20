using Car_Maintenance_App.Model;
using Car_Maintenance_App.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.Services
{
    public class ServiceService
    {
        public static void CreateService(int carId, int userId, ServiceType type, string description)
        {
            // Logic to create a new service record
            Service newService = new Service
            {
                CarId = carId,
                UserId = userId,
                Status = ServiceStatus.Pending, // Default status
                Type = type,
                Description = description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            DatabaseHelper.Insert(newService);
        }
    }
}
