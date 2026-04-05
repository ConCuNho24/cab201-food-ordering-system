using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for handling the deliverer menu in the Arriba Eats application.
    /// </summary>
    internal class HandleDelivererMenu
    {
        private Client client;
        private List<Order> currentListOrder;

        /// <summary>
        /// Constructor for the HandleDelivererMenu class.
        /// </summary>
        /// <param name="client"></param>
        public HandleDelivererMenu(Client client)
        {
            this.client = client;
            currentListOrder = new List<Order>();
        }

        /// <summary>
        /// This method runs the Handle Deliverer menu, allowing the user to select an order that a deliverer has collected.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            GenerateCurrentListOrder();
            const string HEADER_STR = "These deliverers have arrived and are waiting to collect orders.\nSelect an order to indicate that the deliverer has collected it:";
            int lastOption = currentListOrder.Count;

            // Displaying the list of current orders with deliverers that have arrived and return the user's choice
            int userChoice = CmdLineUI.GetChoiceFromListOption(currentListOrder,
                                      order => $"Order #{order.Number} for {order.GetCustomerName()} (Deliverer licence plate: {order.GetDelivererPlate()}) (Order status: {order.Status})", HEADER_STR);


            if (userChoice == lastOption) return true;
            HandleOrder(userChoice);
            return true;
        }

        /// <summary>
        /// This method generates a list of current orders that have deliverers who have arrived and are waiting to collect them.
        /// </summary>
        private void GenerateCurrentListOrder()
        {
            foreach (Order order in client.GetRestaurant().GetListOrder())
            {
                if (order.isDelivererArrived && (order.Status == OrderStatus.Ordered || order.Status == OrderStatus.Cooking || order.Status == OrderStatus.Cooked))
                {
                    currentListOrder.Add(order);
                }
            }
        }

        /// <summary>
        /// This method handles the order selected by the user, marking it as being delivered if it has been cooked.
        /// </summary>
        /// <param name="userChoice">Take user choice</param>
        private void HandleOrder(int userChoice)
        {
            // getting the chosen order based on the user's choice
            Order chosenOrder = currentListOrder[userChoice];

            if (chosenOrder.Status != OrderStatus.Cooked) //Check if the order has been cooked
            {
                CmdLineUI.DisplayMessage("This order has not yet been cooked.");
            }
            else
            {
                chosenOrder.UpdateStatus(OrderStatus.BeingDelivered);
                CmdLineUI.DisplayMessage($"Order #{chosenOrder.Number} is now marked as being delivered.");
            }

        }
        
    }
}
