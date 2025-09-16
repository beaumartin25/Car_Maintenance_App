using Car_Maintenance_App.Model;
using Car_Maintenance_App.Services;
using Car_Maintenance_App.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.ViewModel
{
    public class ServiceDetailVM
    {
        public Service Service { get; set; }

        public List<ServiceStatus> StatusOptions { get; } =
            Enum.GetValues(typeof(ServiceStatus)).Cast<ServiceStatus>().ToList();

        public ServiceStatus Status { get; set; }

        public UpdateServiceCommand UpdateServiceCommand { get; set; }

        public ServiceDetailVM(Service service)
        {
            Service = service;

            UpdateServiceCommand = new UpdateServiceCommand(this);

        }

        public void UpdateService()
        {
            ServiceService.UpdateService(
                Service.Id,
                Service.CarId,
                Service.UserId,
                Service.Status,
                Service.Type,
                Service.Description,
                Service.ServiceDate
            );

        }

    }
}
