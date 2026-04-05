using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    internal class User
    {
        /// <summary>
        /// This is a class representing a user in the Arriba Eats application.
        /// </summary>
        public string Name { get; protected set; }
        private int Age;
        public string Email { get; protected set; }
        private string MobilephoneNumber;
        public string Password { get; private set; }

        /// <summary>
        /// This is a constructor for the User class, which initializes the user with their name, age, email, mobile phone number, and password.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="Email"></param>
        /// <param name="MobilephoneNumber"></param>
        /// <param name="Password"></param>
        protected User(string Name, int Age, string Email, string MobilephoneNumber, string Password)
        {
            this.Name = Name;
            this.Age = Age;
            this.Email = Email;
            this.MobilephoneNumber = MobilephoneNumber;
            this.Password = Password;
        }

        /// <summary>
        /// This method returns a string containing the user's information, including their name, age, email, and mobile phone number.
        /// </summary>
        /// <returns></returns>
        public virtual string GetUserInfo()
        {
            return "Your user details are as follows:" + "\n" +
                   $"Name: {Name}" + "\n" +
                   $"Age: {Age}" + "\n" +
                   $"Email: {Email}" + "\n" +
                   $"Mobile: {MobilephoneNumber}";
        }
    }
}
