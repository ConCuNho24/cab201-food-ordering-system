using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for managing user data in the Arriba Eats application.
    /// </summary>
    internal class UserRepository
    {
        /// <summary>
        /// This is a static list that holds all registered users in the application.
        /// </summary>
        private static readonly List<User> ListUser = new List<User>();

        /// <summary>
        /// This method adds a new user to the list of registered users.
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            ListUser.Add(user);
        }

        /// <summary>
        /// This method retrieves a list of all registered email addresses from the user repository.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetRegisteredEmailList()
        {
            List<string> RegisteredEmailList= new List<string>();   

            foreach (User user in ListUser)
            {
                RegisteredEmailList.Add(user.Email);
            }
            return new List<string>(RegisteredEmailList);
        }

        /// <summary>
        /// This method authenticates a user based on their email and password.
        /// </summary>
        /// <param name="email">get user's email</param>
        /// <param name="password">get user's password</param>
        /// <returns></returns>
        public static User Authenticate(string email, string password)
        {
            foreach (User user in ListUser)
            {
                if (email == user.Email && password == user.Password)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
