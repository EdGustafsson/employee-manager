﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace EmployeeManager.Users
{
    public class FileUserRepository : IUserRepository
    {
        private readonly string _fileName = "Users.csv";
        private readonly List<User> _users = new List<User>();
        public FileUserRepository()
        {

            if (!File.Exists(_fileName))
            {
                using (File.Create(_fileName)) { }
            }

            //_users = File.ReadAllLines(_fileName)
            //                               .Skip(1)
            //                               .Select(v => User.FromCsv(v))
            //                               .ToList();

            string line;

            using (StreamReader file = File.OpenText(_fileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    _users.Add(new User(words[0], words[1], words[2], words[3], words[4], words[5]));
                }

            }    
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User GetUser(string id, string password)
        {
            return _users.Single(e => e.Id == id && e.Password == password);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }
        public void Save()
        {
            using (var file = File.CreateText(_fileName))
            {
                foreach (var arr in _users)
                {
                    file.WriteLine(string.Join(",", arr));
                }

            }
        }


    }
}
