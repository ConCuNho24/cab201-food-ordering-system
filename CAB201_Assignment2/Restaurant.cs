using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is an enum class for defining different styles of restaurants in the Arriba Eats application.
    /// </summary>
    public enum RestaurantStyle
    {
        Italian,
        French,
        Chinese,
        Japanese,
        American,
        Australian
    }

    /// <summary>
    /// This is a class for representing a restaurant in the Arriba Eats application.
    /// </summary>
    internal class Restaurant
    {
        public string Name { get; private set; }
        public RestaurantStyle Style { get; private set; }
        public Location location { get; private set; }
        private List<MenuItem> ListMenu = new List<MenuItem>(); // List of menu items available in the restaurant
        private List<Order> ListOrder = new List<Order>(); // List of orders placed at the restaurant

        /// <summary>
        /// Constructor for the Restaurant class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="style"></param>
        /// <param name="location"></param>
        public Restaurant(string name, RestaurantStyle style, Location location)
        {
            Name = name;
            this.Style = style;
            this.location = location;
        }

        /// <summary>
        /// This method returns the current list order
        /// </summary>
        /// <returns></returns>
        public List<Order> GetListOrder()
        {
            return new List<Order>(ListOrder);
        }

        /// <summary>
        /// This method returns the list of menu items available in the restaurant.
        /// </summary>
        /// <returns></returns>
        public List<MenuItem> GetMenuList()
        {
            return new List<MenuItem>(ListMenu);
        }

        /// <summary>
        /// This method adds a new menu item to the restaurant's menu.
        /// </summary>
        /// <param name="item"></param>
        public void AddToMenu(MenuItem item)
        {
            ListMenu.Add(item);
        }

        /// <summary>
        /// This method updates the to restaurant's order list with a new order.
        /// </summary>
        /// <param name="order"></param>
        public void UpdateToOrderList(Order order)
        {
            ListOrder.Add(order);
        }

        /// <summary>
        /// This method retrieves a list of ratings from all orders in the restaurant.
        /// </summary>
        /// <returns></returns>
        public List<Rating> GetListRating()
        {
            List<Rating> ListRating = new List<Rating>();
            foreach (var order in ListOrder)
            {
                if (order != null && order.GetOrderRating() != null)
                {
                    ListRating.Add(order.GetOrderRating());
                }
            }
            return new List<Rating>(ListRating);
        }

        /// <summary>
        /// This method calculates the average rating of the restaurant based on the ratings from all orders.
        /// </summary>
        /// <returns></returns>
        public double GetAverageRating()
        {

            double totalStar = 0;
            List<Rating> ListRating = GetListRating();
            if (ListRating.Count == 0) return 0;
            foreach (var rating in ListRating)
            {
                totalStar += rating.Star;
            }
            double averageRating = Math.Ceiling(totalStar / ListRating.Count * 10) / 10;
            return averageRating;
        }

        /// <summary>
        /// This method returns the average rating of the restaurant as a string formatted to one decimal place.
        /// </summary>
        /// <returns></returns>
        public string GetAverageRatingString()
        {
            List<Rating> listRating = GetListRating();
            string rating;
            if (listRating.Count == 0)
            {
                rating = "-";
            }
            else
            {
                rating = GetAverageRating().ToString("F1");
            }
            return rating;
        }

    }  
}

