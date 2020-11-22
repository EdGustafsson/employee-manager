using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace EmployeeManager.Users
{
    public class FileUserRepository : IUserRepository
    {
        private readonly string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string _applicationDirectory = "EmployeeManager";
        private readonly string _fileName = "Users.csv";
        private readonly string _path;
        private readonly List<User> _users = new List<User>();
        public FileUserRepository()
        {
            var directory = Path.Combine(_appData, _applicationDirectory);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var path = Path.Combine(directory, _fileName);

            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }

            _path = path;


            string line;

            using (StreamReader file = File.OpenText(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    _users.Add(new User(words[0], words[1], words[2], words[3], words[4]));
                }

            }
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User GetUser(string id)
        {

            return _users.Single(e => e.Id == id);

        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }
        public void UpdateUser(User user, string selection, string newValue)
        {
            switch (selection)
            {
                case "id":
                    user.Id = newValue;
                    break;
                case "name":
                    user.Id = newValue;
                    break;
                case "password":
                    user.Id = newValue;
                    break;
                case "address":
                    user.Id = newValue;
                    break;
            }

        }

        public void Save()
        {
            using (var file = File.CreateText(_path))
            {
                foreach (var user in _users)
                {

                    file.WriteLine(user.Id + "," + user.Name + "," + user.Password + "," + user.Address + "," + user.Admin);
                }

            }
        }


        public bool UserExist(string id)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UserExist(string id, string password)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == id && _users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AdminExist(string id, string password, string admin)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == id && _users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
