using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.Model
{
    public enum ServiceStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public enum ServiceType
    {
        OilChange,
        TireRotation,
        BrakeInspection,
        EngineTuneUp,
        Other
    }
}
