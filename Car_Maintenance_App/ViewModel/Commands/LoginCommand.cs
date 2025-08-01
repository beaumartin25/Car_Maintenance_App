﻿using Car_Maintenance_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Car_Maintenance_App.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public event EventHandler? CanExecuteChanged;

        // Constructor
        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object? parameter)
        {
            User user = parameter as User;

            if (user == null)
                return false;
            if (string.IsNullOrEmpty(user.Username))
                return false;
            if (string.IsNullOrEmpty(user.Password))
                return false;
            {

            }
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.Login();
        }
    }
}
