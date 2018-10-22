using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KashiHomeFood.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        private static int nextId = 1;
        public DateTime CreateDate;

        public User()
        {
            UserId = nextId;
            nextId++;
            CreateDate = DateTime.Now;

        }

        public User(string Username, string Email, string Password)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;

        }
    }
}
