using Backend1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend1.Repository
{
    public static class UserRepository
    {
        private static readonly List<User> Users = new List<User>();

        // Static constructor to initialize the user list
        static UserRepository()
        {
            Users.Add(new User { Name = "Meet Joshi", Role = 1, Password = "JayBajranbali" });
            Users.Add(new User { Name = "Rohanshu Banodha", Role = 2, Password = "Jay" });
            Users.Add(new User { Name = "Keyur Sir", Role = 2, Password = "RKIT" });
            Users.Add(new User { Name = "Navneet Sir", Role = 3, Password = "Khankuva" });
        }

        public static void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            Users.Add(user);
        }

        public static bool VerifyUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var existingUser = Users.FirstOrDefault(u => u.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase));

            if (existingUser == null)
            {
                throw new Exception("No such user found.");
            }

            if (existingUser.Password != user.Password)
            {
                throw new Exception("Incorrect password.");
            }
            user.Role = existingUser.Role;
            return true;
        }
    }
}
