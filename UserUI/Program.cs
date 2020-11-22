using System;
using EmployeeManager.Users;
using EmployeeManager;
using System.Collections.Generic;
using System.Linq;


namespace UserUI
{
    class Program
    {

        private static Login _login;
        private static Manager _manager;
        private static User _activeUser;

        static void Main(string[] args)
        {
            Console.WriteLine("EmployeeManager User 1.0\n");

            _login = new Login();
            _manager = new Manager();


            _activeUser = _login.LoginUser();

            _manager.UserMain(_activeUser);


        }
    }
}
