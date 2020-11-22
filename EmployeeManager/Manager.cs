using System;
using EmployeeManager.Users;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager
{
    public class Manager
    {

        private static IUserRepository _userRepository;
        public void AdminMain()
        {
            _userRepository = new FileUserRepository();

            while (true)
            {

                Console.WriteLine("\nMAIN MENU");
                Console.WriteLine("\nEnter a to list all users");
                Console.WriteLine("Enter c to create new user");
                Console.WriteLine("Enter d to delete a user");
                Console.WriteLine("Enter e to edit a user");
                Console.WriteLine("Enter x at any point to return to the main menu");



                string userChoice = Console.ReadLine();

                if (userChoice == "a")
                {
                    PrintUsers();
                }
                else if (userChoice == "c")
                {
                    CreateUser();
                }
                else if (userChoice == "d")
                {
                    DeleteUser();
                }
                else if (userChoice == "e")
                {
                    AdminEditUser();
                }
                else
                {
                    Console.WriteLine("\nPlease enter one of the choices below");
                }

            }
        }

        public void UserMain(User activeUser)
        {
            while (true)
            {
                Console.WriteLine("\nMAIN MENU");
                Console.WriteLine("Enter x at any point to return to the main menu");

                _userRepository = new FileUserRepository();

                EditUser(activeUser);
            }

        }




        public void PrintUsers()
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

        public void CreateUser()
        {

            string input1 = "";
            string input2 = "";
            string input3 = "";
            string input4 = "";
            string input5 = "";

            Console.WriteLine("\nEnter new user ID");

            while (true)
            {
                input1 = Console.ReadLine();

                if (input1 == "x")
                {
                    return;
                }
                else if (_userRepository.UserExist(input1))
                {
                    Console.WriteLine("\nA user with that ID already exists, please choose another");
                }
                else if (!input1.All(char.IsDigit))
                {
                    Console.WriteLine("\nID can only be numbers");
                }
                else
                {
                    break;
                }
            }


            Console.WriteLine("Enter name");
            input2 = Console.ReadLine();

            if (input2 == "x")
            {
                return;
            }

            Console.WriteLine("Enter password");
            input3 = Console.ReadLine();

            if (input3 == "x")
            {
                return;
            }

            Console.WriteLine("Enter address");
            input4 = Console.ReadLine();

            if (input4 == "x")
            {
                return;
            }

            Console.WriteLine("Should the user have admin privileges? Enter y or n");

            while (true)
            {

                input5 = Console.ReadLine();
                if (input5 == "x")
                {
                    return;
                }
                else if (input5 == "y" || input5 == "n")
                {
                    break;
                }

                Console.WriteLine("Enter 'y' for yes or 'n' for no");

            }




            if (input5 == "y")
            {
                input5 = "1";
            }
            else if (input5 == "n")
            {
                input5 = "0";
            }


            User newUser = new User(input1, input2, input3, input4, input5);

            _userRepository.AddUser(newUser);
            _userRepository.Save();


        }
        public void DeleteUser()
        {
            while (true)
            {

                List<User> _users = _userRepository.GetUsers();

                Console.WriteLine("Type the ID of the user you would like to delete");
                string userInput = Console.ReadLine();

                if (userInput == "x")
                {
                    return;
                }
                else if (_userRepository.UserExist(userInput))
                {
                    User selectedUser = _users.Single(e => e.Id == userInput);

                    _userRepository.RemoveUser(selectedUser);
                    _userRepository.Save();
                }
                else
                {
                    Console.WriteLine("No user with that ID found");
                }

            }


        }

        public void AdminEditUser()
        {
            List<User> _users = _userRepository.GetUsers();

            Console.WriteLine("Type the ID of the user you would like to edit");
            string userInput = Console.ReadLine();

            if (userInput == "x")
            {
                return;
            }
            else if (_userRepository.UserExist(userInput))
            {
                User selectedUser = _users.Single(e => e.Id == userInput);

                EditUser(selectedUser);

            }
            else
            {
                Console.WriteLine("No user with that ID found");
            }

        }

        public void EditUser(User user)
        {
            List<User> _users = _userRepository.GetUsers();

            User selectedUser = _users.Single(e => e.Id == user.Id);

            Console.WriteLine("\nAccount information");
            Console.WriteLine("Id = " + selectedUser.Id);
            Console.WriteLine("Name = " + selectedUser.Name);
            Console.WriteLine("Password = " + selectedUser.Password);
            Console.WriteLine("Address = " + selectedUser.Address);

            Console.WriteLine("\nEnter which item you would like to change");
            Console.WriteLine("In lowercase only (e.g., id, name, password, address)");

            string userChoice = Console.ReadLine();



            if (userChoice == "x")
            {
                return;
            }
            else if (userChoice == "id")
            {
                while (true)
                {
                    Console.Write("\nEnter new id:");
                    string userInput = Console.ReadLine();

                    if (userInput == "x")
                    {
                        return;
                    }
                    else if (_userRepository.UserExist(userInput))
                    {
                        Console.WriteLine("\nA user with that ID already exists");
                    }
                    else if (!userInput.All(char.IsDigit))
                    {
                        Console.WriteLine("\nID can only be numbers");
                    }
                    else
                    {

                        selectedUser.Id = userInput;
                        break;
                    }
                }

            }
            else if (userChoice == "name")
            {
                Console.Write("\nEnter new name:");
                string userInput = Console.ReadLine();


                if (userInput == "x")
                {
                    return;
                }

                selectedUser.Name = userInput;
                _userRepository.Save();
            }
            else if (userChoice == "password")
            {
                Console.Write("\nEnter new password:");
                string userInput = Console.ReadLine();


                if (userInput == "x")
                {
                    return;
                }

                selectedUser.Password = userInput;
                _userRepository.Save();
            }
            else if (userChoice == "address")
            {
                Console.Write("\nEnter new address:");
                string userInput = Console.ReadLine();


                if (userInput == "x")
                {
                    return;
                }

                selectedUser.Address = userInput;
                _userRepository.Save();
            }
            else
            {
                Console.WriteLine("\nPlease enter one of the choices below");
            }

            _userRepository.Save();



        }
    }
}
