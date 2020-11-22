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

                Console.WriteLine("\nEnter a to list all users");
                Console.WriteLine("Enter c to create new user");
                Console.WriteLine("Enter d to delete a user");
                Console.WriteLine("Enter e to edit a user");



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
                if (userChoice == "e")
                {
                    EditUser();
                }

            }
        }

        public void UserMain(User activeUser)
        {
            _userRepository = new FileUserRepository();

            EditUser(activeUser);

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

                if (input5 == "y")
                {
                    input5 = "1";
                }
                else if (input5 == "n")
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
        public void DeleteUser()
        {
            List<User> _users = _userRepository.GetUsers();

            Console.WriteLine("Type the ID of the user you would like to delete");
            string userInput = Console.ReadLine();

            User selectedUser = _users.Single(e => e.Id == userInput);
            _userRepository.RemoveUser(selectedUser);
            _userRepository.Save();

        }

        public void EditUser()
        {
            List<User> _users = _userRepository.GetUsers();

            Console.WriteLine("Type the ID of the user you would like to edit");
            string userInput = Console.ReadLine();

            User selectedUser = _users.Single(e => e.Id == userInput);


            Console.WriteLine("\nAccount information");
            Console.WriteLine("Id = " + selectedUser.Id);
            Console.WriteLine("Name = " + selectedUser.Name);
            Console.WriteLine("Password = " + selectedUser.Password);
            Console.WriteLine("Address = " + selectedUser.Address);

            Console.WriteLine("\n Enter which item you would like to change");
            Console.WriteLine("In lowercase only (e.g., id, name, password, address)");

            string userChoice = Console.ReadLine();




            if (userChoice == "id")
            {
                while (true)
                {
                    Console.Write("\nEnter new id:");
                    string id = Console.ReadLine();

                    if (_userRepository.UserExist(id))
                    {
                        Console.WriteLine("\nA user with that ID already exists");
                    }
                    else
                    {

                        selectedUser.Id = id;
                        break;
                    }
                }

            }
            else
            {
                switch (userChoice)
                {

                    case "name":
                        Console.Write("\nEnter new name:");
                        selectedUser.Name = Console.ReadLine();
                        break;
                    case "password":
                        Console.Write("\nEnter new password:");
                        selectedUser.Password = Console.ReadLine();
                        break;
                    case "address":
                        Console.Write("\nEnter new address:");
                        selectedUser.Address = Console.ReadLine();
                        break;
                }
            }

            _userRepository.Save();





        }

        public void EditUser(User activeUser)
        {
            while (true)
            {
                List<User> _users = _userRepository.GetUsers();

                User selectedUser = _users.Single(e => e.Id == activeUser.Id);

                Console.WriteLine("\nAccount information");
                Console.WriteLine("Id = " + selectedUser.Id);
                Console.WriteLine("Name = " + selectedUser.Name);
                Console.WriteLine("Password = " + selectedUser.Password);
                Console.WriteLine("Address = " + selectedUser.Address);

                Console.WriteLine("\nEnter which item you would like to change");
                Console.WriteLine("In lowercase only (e.g., id, name, password, address)");

                string userChoice = Console.ReadLine();




                if (userChoice == "id")
                {
                    while (true)
                    {
                        Console.Write("\nEnter new id:");
                        string id = Console.ReadLine();

                        if (_userRepository.UserExist(id))
                        {
                            Console.WriteLine("\nA user with that ID already exists");
                        }
                        else
                        {

                            selectedUser.Id = id;
                            break;
                        }
                    }

                }
                else
                {
                    switch (userChoice)
                    {

                        case "name":
                            Console.Write("\nEnter new name:");
                            selectedUser.Name = Console.ReadLine();
                            break;
                        case "password":
                            Console.Write("\nEnter new password:");
                            selectedUser.Password = Console.ReadLine();
                            break;
                        case "address":
                            Console.Write("\nEnter new address:");
                            selectedUser.Address = Console.ReadLine();
                            break;
                    }
                }

                _userRepository.Save();

            }

        }
    }
}
