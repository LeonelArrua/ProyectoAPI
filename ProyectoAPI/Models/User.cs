using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPI
{
    public class User
    {
        private long _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _email;

        public User()
        {
        }
        public User(long id, string firstName, string lastName, string userName, string password, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public long Id { get => _id; set => _id = value; }
    }
}
