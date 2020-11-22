using System;
using EmployeeManager;
using EmployeeManager.Users;
using System.Collections.Generic;
using System.Linq;

namespace AdminUI
{
    class Program
    {

        private static Login _login;
        private static Manager _manager;
        static void Main(string[] args)
        {
            Console.WriteLine("EmployeeManager Admin 1.0");

            _login = new Login();
            _manager = new Manager();


            _login.LoginAdmin();

            _manager.AdminMain();

        }
    }
}
