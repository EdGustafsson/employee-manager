using System;
using EmployeeManager.Users;
using System.Collections.Generic;
using System.Linq;

namespace AdminUI
{
    class Program
    {

        private static IUserRepository _userRepository;
        static void Main(string[] args)
        {

            _userRepository = new FileUserRepository();

            Console.WriteLine("EmployeeManager Admin 1.0\n");

            while (true)
            {

                Console.WriteLine("\nEnter admin ID:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("\nEnter admin password");
                string userInput2 = Console.ReadLine();

                if (_userRepository.UserExist(userInput1, userInput2))
                {
                    break;
                }

                Console.WriteLine("Wrong ID or password");

            }



            Console.WriteLine("");


            Console.WriteLine("\nSuccessful Log in");


            Console.WriteLine("\nEnter a to list all users");
            Console.WriteLine("Enter c to create new user");
            Console.WriteLine("Enter d to delete a user");

            string userChoice = Console.ReadLine();


            if (userChoice == "a")
            {

                List<User> _users = _userRepository.GetUsers();

                for (int i = 0; i < _users.Count; i++)
                {
                    Console.WriteLine($"\n{_users[i].Id}\n{_users[i].Name}\n{_users[i].Password}\n{_users[i].Address}\n{_users[i].Admin}\n");
                }

            }
            if (userChoice == "c")
            {

                Console.WriteLine("Enter new user ID");
                string input1 = Console.ReadLine();
                Console.WriteLine("Enter name");
                string input2 = Console.ReadLine();
                Console.WriteLine("Enter password");
                string input3 = Console.ReadLine();
                Console.WriteLine("Enter address");
                string input4 = Console.ReadLine();
                Console.WriteLine("Should the user have admin privileges? Enter y or n");
                string input5 = Console.ReadLine();

                User newUser = new User(input1, input2, input3, input4, input5);

                _userRepository.AddUser(newUser);
                _userRepository.Save();


            }
            if (userChoice == "d")
            {
                List<User> _users = _userRepository.GetUsers();

                Console.WriteLine("Type the ID of the user you would like to delete");
                string userInput = Console.ReadLine();

                User selectedUser = _users.Single(e => e.Id == userInput);
                _userRepository.RemoveUser(selectedUser);


            }
        }
    }
}
