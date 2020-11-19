using System;
using EmployeeManager.Users;

namespace AdminUI
{
    class Program
    {

        private static IUserRepository _userRepository;
        static void Main(string[] args)
        {

            _userRepository = new FileUserRepository();

            while (true) { 

            Console.WriteLine("EmployeeManager Admin 1.0\n\nEnter admin ID:");
            string userInput1 = Console.ReadLine();
            Console.WriteLine("\nEnter admin password");
            string userInput2 = Console.ReadLine();

                _userRepository.GetUser(userInput1, userInput2);

            }

        }
    }
}
