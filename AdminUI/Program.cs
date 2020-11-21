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

            Console.WriteLine("EmployeeManager Admin 1.0");

            User activeUser;

            while (true)
            {

                Console.WriteLine("\nEnter admin ID:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("\nEnter admin password");
                string userInput2 = Console.ReadLine();


                if (_userRepository.UserExist(userInput1, userInput2))
                {

                    activeUser = _userRepository.GetUser(userInput1);

                    if (activeUser.Admin == "1")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nUser does not have admin permission");
                    }

                }

                Console.WriteLine("\nWrong ID or password");

            }

            while (true)
            {

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
                    string admin;

                    if (_users[i].Admin == "1")
                    {
                        admin = "Yes";
                    }
                    else
                    {
                        admin = "No";
                    }

                    Console.WriteLine($"\nUser {i + 1}");
                    Console.WriteLine($"ID: {_users[i].Id}\nName: {_users[i].Name}\nPassword: {_users[i].Password}\nAddress: {_users[i].Address}\nAdmin Access: {admin}");

                }

            }
            if (userChoice == "c")
            {
                bool a = true;

                while (a)
                {
                    Console.WriteLine("\nEnter new user ID");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter name");
                    string input2 = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string input3 = Console.ReadLine();
                    Console.WriteLine("Enter address");
                    string input4 = Console.ReadLine();
                    Console.WriteLine("Should the user have admin privileges? Enter y or n");
                    string input5 = Console.ReadLine();

                    if(input5 == "y")
                    {
                        input5 = "1";
                    }
                    else if(input5 == "n")
                    {
                        input5 = "0";
                    }

                    if (_userRepository.UserExist(input1))
                    {
                        Console.WriteLine("\nA user with that ID already exists");
                    }
                    else
                    {

                        User newUser = new User(input1, input2, input3, input4, input5);

                        _userRepository.AddUser(newUser);
                        _userRepository.Save();
                        a = false;
                    }
                }
            }

            if (userChoice == "d")
            {
                List<User> _users = _userRepository.GetUsers();

                Console.WriteLine("Type the ID of the user you would like to delete");
                string userInput = Console.ReadLine();

                User selectedUser = _users.Single(e => e.Id == userInput);
                _userRepository.RemoveUser(selectedUser);
                _userRepository.Save();
            }


            }
        }
    }
}
