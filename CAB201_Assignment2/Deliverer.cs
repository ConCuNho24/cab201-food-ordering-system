using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for representing a deliverer in the Arriba Eats application.
    /// </summary>
    internal class Deliverer : User
    {
        public string LicencePlate { get; private set; }
        private Order currentOrder; 
        public Location location { get; private set; }

        /// <summary>
        /// Constructor for the Deliverer class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="email"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="password"></param>
        /// <param name="licenePlate"></param>
        public Deliverer(string name, int age, string email, string mobileNumber, string password, string licenePlate) : base(name, age, email, mobileNumber, password)
        {
            LicencePlate = licenePlate;
        }

        /// <summary>
        /// This method is used to mark the deliverer as available for a new order by setting the current order to null.
        /// </summary>
        public void FinishOrder()
        {
            currentOrder = null;    
        }

        /// <summary>
        /// This method returns the current order that the deliverer is handling.
        /// </summary>
        /// <returns></returns>
        public Order GetCurrentOrder()
        {
            return currentOrder;
        }

        /// <summary>
        /// This method checks if the deliverer is currently handling an order.
        /// </summary>
        /// <returns></returns>
        public bool CurentlyHavingOrder()
        {
            return currentOrder != null;
        }

        /// <summary>
        /// This method updates the current order for the deliverer, allowing them to accept a new order.
        /// </summary>
        /// <param name="order">current order</param>
        public void UpdateCurrentOrder(Order order)
        {
            currentOrder = order;
        }

        /// <summary>
        /// This method returns a string containing the deliverer's user information, including their licence plate and current order details if they have one.
        /// </summary>
        /// <returns></returns>
        public override string GetUserInfo()
        {
            string userInfo = base.GetUserInfo() +"\n" + 
                              $"Licence plate: {LicencePlate}";

            if (CurentlyHavingOrder())
            {
                Order order = GetCurrentOrder();
                return userInfo  + "Current delivery:" + "\n" +
                       $"Order #{order.Number} from {order.GetRestaurantName()} at {order.GetRestaurantLocation().ToString()}." + "\n" +
                       $"To be delivered to {order.GetCustomerName()} at {order.GetCustomerLocation().ToString()}.";
            }
            return userInfo;
        }
    }
}
