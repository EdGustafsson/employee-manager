using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Users
{
    public interface IUserRepository
    {

        List<User> GetUsers();
        User GetUser(string id);
        void AddUser(User user);
        void RemoveUser(User user);

        void UpdateUser(User user, string selection, string newValue);
        void Save();
        bool UserExist(string id, string password);


    }
}
