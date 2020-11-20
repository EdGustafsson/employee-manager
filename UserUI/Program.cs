using System;
using EmployeeManager.Users;
using System.Collections.Generic;
using System.Linq;


namespace UserUI
{
    class Program
    {
        private static IUserRepository _userRepository;

        static void Main(string[] args)
        {
            _userRepository = new FileUserRepository();

            Console.WriteLine("EmployeeManager User 1.0\n");

            User activeUser;




            while (true)
            {

                Console.WriteLine("\nEnter user ID:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("\nEnter user password");
                string userInput2 = Console.ReadLine();

                if (_userRepository.UserExist(userInput1, userInput2))
                {

                    activeUser = _userRepository.GetUser(userInput1);

                    break;

                }

                Console.WriteLine("Wrong ID or password");

            }

            Console.WriteLine("\nSuccessful Log in\n");

            while (true)
            {
                Console.WriteLine("Id = " + activeUser.Id);
                Console.WriteLine("Name = " + activeUser.Name);
                Console.WriteLine("Password = " + activeUser.Password);
                Console.WriteLine("Address = " + activeUser.Address);

                Console.WriteLine("\nEnter which item you would like to change");
                Console.WriteLine("'id' for Id");
                Console.WriteLine("'name' for Id");
                Console.WriteLine("'password' for Id");
                Console.WriteLine("'address' for Id");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "id":
                        Console.Write("\nEnter new id:");
                        activeUser.Id = Console.ReadLine();
                        break;
                    case "name":
                        Console.Write("\nEnter new name:");
                        activeUser.Name = Console.ReadLine();
                        break;
                    case "password":
                        Console.Write("\nEnter new password:");
                        activeUser.Password = Console.ReadLine();
                        break;
                    case "address":
                        Console.Write("\nEnter new address:");
                        activeUser.Address = Console.ReadLine();
                        break;
                }



                _userRepository.Save();

            }




        }
    }
}
