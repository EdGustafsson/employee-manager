using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Users;

namespace EmployeeManager
{
    public class Login
    {

        private static IUserRepository _userRepository;
        public User LoginUser()
        {
            while (true)
            {

                _userRepository = new FileUserRepository();
                User activeUser;

                Console.WriteLine("\nEnter user ID:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("\nEnter user password");
                string userInput2 = Console.ReadLine();

                if (_userRepository.UserExist(userInput1, userInput2))
                {

                    activeUser = _userRepository.GetUser(userInput1);

                    Console.WriteLine("\nSuccessful Log in\n");

                    return activeUser;

                }

                Console.WriteLine("Wrong ID or password");

            }


        }

        public void LoginAdmin()
        {
            while (true)
            {
                _userRepository = new FileUserRepository();
                User activeUser;

                Console.WriteLine("\nEnter admin ID:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("\nEnter admin password");
                string userInput2 = Console.ReadLine();


                if (_userRepository.UserExist(userInput1, userInput2))
                {

                    activeUser = _userRepository.GetUser(userInput1);

                    if (activeUser.Admin == "1")
                    {
                        Console.WriteLine("\nSuccessful Log in\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nUser does not have admin permission");
                    }

                }

                Console.WriteLine("\nWrong ID or password");

            }


        }
    }
}
