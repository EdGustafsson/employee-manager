using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Users
{
    public class User
    {

        public User(string id, string name, string password ,string address, string admin)
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
        public string Address { get;set; }
        public string Admin { get; set; }

        //public static User FromCsv(string csvLine)
        //{
        //    string[] values = csvLine.Split(',');
        //    Guid userID = Convert.togu(values[0]);



        //    User user = new User();
        //    User.id = Convert.ToDateTime(values[0]);
        //    User.fi = Convert.ToDecimal(values[1]);
        //    User.High = Convert.ToDecimal(values[2]);
        //    User.Low = Convert.ToDecimal(values[3]);
        //    User.Close = Convert.ToDecimal(values[4]);
        //    User.Volume = Convert.ToDecimal(values[5]);
        //    User.AdjClose = Convert.ToDecimal(values[6]);
        //    return dailyValues;
        //}
    }
}
