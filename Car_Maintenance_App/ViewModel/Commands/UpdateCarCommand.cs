using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Car_Maintenance_App.ViewModel.Commands
{
    public class UpdateCarCommand : ICommand
    {
        public CarDetailVM VM { get; set; }
        public event EventHandler? CanExecuteChanged;
        // Constructor
        public UpdateCarCommand(CarDetailVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true; // Add validation logic if needed
        }
        public void Execute(object? parameter)
        {
            VM.UpdateCar();
        }
    }
}
