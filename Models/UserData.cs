using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KashiHomeFood.Models
{
    public class UserData
    {
        static private List<User> users = new List<User>();
        public static List<User> GetAll()
        {
            return users;
        }

        public static User GetById(int userId)
        {
            return users.Single(x => x.UserId == userId);
        }

        public static void Add(User newUser)
        {
            users.Add(newUser);
        }
    }
}
