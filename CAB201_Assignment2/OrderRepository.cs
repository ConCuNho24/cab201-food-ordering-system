using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a repository class for managing orders in the Arriba Eats application.
    /// </summary>
    internal class OrderRepository
    {
        private static readonly List<Order> ListOrder = new List<Order>();

        /// <summary>
        /// This method adds an order to the list of orders.
        /// </summary>
        /// <param name="order"></param>
        private static void AddOrder(Order order)
        {
            ListOrder.Add(order);
        }

        /// <summary>
        /// This method retrieves the current order number based on the number of existing orders in the list.
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentNumber()
        {
            return ListOrder.Count + 1;   
        }

        /// <summary>
        /// This method retrieves a list of all orders currently in the repository.
        /// </summary>
        /// <returns></returns>
        public static List<Order> GetList()
        {
            return new List<Order> (ListOrder);
        }

        /// <summary>
        /// This method processes an order by placing it with the customer, adding it to the order list, and updating the restaurant's order list.
        /// </summary>
        /// <param name="order">current order</param>
        /// <param name="customer"> customer placed order</param>
        /// <param name="restaurant">restaurant of that order</param>
        public static void ProcessOrder(Order order, Customer customer, Restaurant restaurant)
        {
            customer.PlaceOrder(order);

           AddOrder(order);

            restaurant.UpdateToOrderList(order);
        }

        /// <summary>
        /// This method processes an order by marking it as cooked and updating the restaurant's order list.
        /// </summary>
        /// <param name="currentOrder"></param>
        /// <param name="deliverer"></param>
        public static void ProcessMarkOrderDelivered(Order currentOrder, Deliverer deliverer)
        {
            currentOrder.UpdateStatus(OrderStatus.Delivered);
            deliverer.FinishOrder();
        }

    }
}
