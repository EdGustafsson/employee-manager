using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Users
{
    public class User
    {

        public User(Guid id, string firstname, string lastname ,string password ,string address, bool admin)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Address = address;
            Admin = admin;
        }

        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public bool Admin { get; private set; }


    }
}
