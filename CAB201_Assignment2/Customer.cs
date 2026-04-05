using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class representing a customer in the Arriba Eats application.
    /// </summary>
    internal class Customer : User
    {
        public Location location { get; private set; }
        private List<Order> ListOrder = new List<Order>();

        /// <summary>
        /// Constructor for the Customer class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="email"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="password"></param>
        /// <param name="location"></param>
        public Customer(string name, int age, string email, string mobileNumber, string password, Location location)
            : base(name, age, email, mobileNumber, password)
        {
            this.location = location;
        }

        /// <summary>
        /// This method allows the customer to place an order by adding it to their list of orders.
        /// </summary>
        /// <param name="order">placed order</param>
        public void PlaceOrder(Order order)
        {
            ListOrder.Add(order);
        }

        /// <summary>
        /// This method returns a list of all orders placed by the customer.
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrderList()
        {
            return new List<Order>(ListOrder);
        }

        /// <summary>
        /// This method returns the total number of orders placed by the customer.
        /// </summary>
        /// <returns></returns>
        public int GetTotalNumberOrder()
        {
            return ListOrder.Count;
        }

        /// <summary>
        /// This method calculates the total price of all orders placed by the customer.
        /// </summary>
        /// <returns></returns>
        public double GetTotalPrice()
        {
            double price = 0;
            foreach (Order order in ListOrder)
            {
                price += order.GetTotalPrice();
            }
            return price;
        }

        /// <summary>
        /// This method returns a string representation of the customer's information, including their location and order history.
        /// </summary>
        /// <returns></returns>
        public override string GetUserInfo()
        {
            return base.GetUserInfo() + "\n" +
                   $"Location: {location.ToString()}" + "\n" +
                   $"You've made {GetTotalNumberOrder()} order(s) and spent a total of ${GetTotalPrice():F2} here.";
        }
    }
}