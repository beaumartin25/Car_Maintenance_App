﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Car_Maintenance_App.ViewModel.Commands
{
    public class ShowRegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public event EventHandler? CanExecuteChanged;

        public ShowRegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.SwitchViews();
        }
    }
}
