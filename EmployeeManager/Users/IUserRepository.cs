using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Users
{
    public interface IUserRepository
    {

        List<User> GetUsers();
        User GetUser(string id, string password);
        void AddUser(User user);
        void RemoveUser(User user);
        void Save();
    }
}
