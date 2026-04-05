using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the current order menu for clients in the Arriba Eats application.
    /// </summary>
    internal class SeeCurrentOrderMenu
    {
        private Client client;
        private Restaurant currentRestaurant;
        private List<Order> UndeliveredListOrder = new List<Order>();

        /// <summary>
        /// Constructor for the SeeCurrentOrderMenu class.
        /// </summary>
        /// <param name="client"></param>
        public SeeCurrentOrderMenu(Client client)
        {
            this.client = client;
            currentRestaurant = client.GetRestaurant();
        }

        /// <summary>
        /// This method is used to run the See Current Order menu, allowing client to see current orders
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {

            GenerateUndeliveredListOrder();

            if (UndeliveredListOrder.Count == 0)
            {
                CmdLineUI.DisplayMessage("Your restaurant has no current orders.");
            }
            else
            {
                DisplayAllOders();
            }

            return true;
        }

        /// <summary>
        /// This method generates a list of undelivered orders from the restaurant's current orders.
        /// </summary>
        private void GenerateUndeliveredListOrder()
        {
            foreach (var order in currentRestaurant.GetListOrder())
            {
                if (order.Status != OrderStatus.BeingDelivered)
                {
                    UndeliveredListOrder.Add(order);
                }
            }
        }

        /// <summary>
        /// Displays all undelivered orders in the restaurant's current orders list.
        /// </summary>
        private void DisplayAllOders()
        {
            foreach (var order in UndeliveredListOrder)
            {
                CmdLineUI.DisplayMessage($"Order #{order.Number} for {order.GetCustomerName()}: {order.Status}");
                CmdLineUI.DisplayListItem(order);
            }
        }
        
    }
}
