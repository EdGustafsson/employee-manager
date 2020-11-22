using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Users
{
    public class User
    {

        public User(string id, string name, string password, string address, string admin)
        {
            Id = id;
            Name = name;
            Password = password;
            Address = address;
            Admin = admin;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Admin { get; set; }

    }
}
