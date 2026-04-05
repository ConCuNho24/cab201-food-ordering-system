using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for managing restaurant data in the Arriba Eats application.
    /// </summary>
    internal class RestaurantRepository
    {
        // This is a private static readonly list that holds all the restaurants in the application.
        private static readonly List<Restaurant> ListRestaurant = new List<Restaurant>();

        /// <summary>
        /// This method retrieves a list of all restaurants currently registered in the application.
        /// </summary>
        /// <returns></returns>
        public static List<Restaurant> GetCurrentListRestaurant()
        {
            return new List<Restaurant>(ListRestaurant);
        }

        /// <summary>
        /// This method adds a new restaurant to the list of registered restaurants.
        /// </summary>
        /// <param name="restaurant">restaunrant need to be added </param>
        public static void AddRestaurant(Restaurant restaurant)
        {
            ListRestaurant.Add(restaurant);
        }

        /// <summary>
        /// This method sorts the list of restaurants by their names in alphabetical order.
        /// </summary>
        /// <param name="ListRestaurant"></param>
        /// <returns></returns>
        public static List<Restaurant> SortByAlphabet(List<Restaurant> ListRestaurant)
        {
            return ListRestaurant.OrderBy(restaurant => restaurant.Name).ToList();
        }

        /// <summary>
        /// This method sorts the list of restaurants by their distance from a given customer location.
        /// </summary>
        /// <param name="customer">current customer choosing sorted restaurant method</param>
        /// <param name="ListRestaurant">list all of restaurant</param>
        /// <returns></returns>
        public static List<Restaurant> SortByDistance(Customer customer, List<Restaurant> ListRestaurant)
        {
            return ListRestaurant.OrderBy(restaurant => restaurant.location.DistanceTo(customer.location))
                                 .ThenBy(restaurant => restaurant.Name).ToList();
        }

        /// <summary>
        /// This method sorts the list of restaurants by their style, and then by their names in alphabetical order.
        /// </summary>
        /// <param name="ListRestaurant">list all restaurant</param>
        /// <returns></returns>
        public static List<Restaurant> SortByStyle(List<Restaurant> ListRestaurant)
        {
            return ListRestaurant.OrderBy(restaurant => restaurant.Style).ThenBy(restaurant => restaurant.Name).ToList();
        }

        /// <summary>
        /// This method sorts the list of restaurants by their average rating, and then by their names in alphabetical order.
        /// </summary>
        /// <param name="ListRestaurant">list all restaurant</param>
        /// <returns></returns>
        public static List<Restaurant> SortByRating(List<Restaurant> ListRestaurant)
        {
            return ListRestaurant.OrderByDescending(restaurant => restaurant.GetAverageRating()).ThenBy(restaurant => restaurant.Name).ToList();
        }
    }
}
