using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for representing a client in the Arriba Eats application.
    /// </summary>
    internal class Client : User
    {
        private Restaurant restaurant;

        /// <summary>
        /// Constructor for the Client class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="email"></param>
        /// <param name="moblieNumber"></param>
        /// <param name="password"></param>
        /// <param name="restaurant"></param>
        public Client (string name, int age, string email, string moblieNumber, string password,  Restaurant restaurant)
            : base (name, age, email, moblieNumber, password)
        {
            this.restaurant = restaurant;
        }

        /// <summary>
        /// This method returns the restaurant associated with the client.
        /// </summary>
        /// <returns></returns>
        public Restaurant GetRestaurant()
        {
            return restaurant;
        }

        /// <summary>
        /// This method returns a string containing the user's information, including the restaurant details.
        /// </summary>
        /// <returns></returns>
        public override string GetUserInfo()
        {
            return base.GetUserInfo() + "\n" +
                   $"Restaurant name: {restaurant.Name}" + "\n" +
                   $"Restaurant style: {restaurant.Style}" + "\n" +
                   $"Restaurant location: {restaurant.location.ToString()}";
        }

    }
}
