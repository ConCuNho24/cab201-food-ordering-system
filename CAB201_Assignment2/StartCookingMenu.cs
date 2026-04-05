using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the start cooking menu for chefs in the Arriba Eats application.
    /// </summary>
    internal class StartCookingMenu
    {   
        private Client client;
        private List<Order> currentListOrder = new List<Order>();

        /// <summary>
        /// Constructor for the StartCookingMenu class.
        /// </summary>
        /// <param name="client"></param>
        public StartCookingMenu(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// This method runs the Start Cooking menu, allowing the user to select an order that has been placed and mark it as cooking.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            GenerateCurrentListOrder();

            const string HEADER_STR = "Select an order once you are ready to start cooking:";
            int lastOption = currentListOrder.Count;

            // Displaying the list of current orders that have been placed and return the user's choice
            int userChoice = CmdLineUI.GetChoiceFromListOption(currentListOrder,
                                        order => $"Order #{order.Number} for {order.GetCustomerName()}", HEADER_STR);

            if (userChoice == lastOption) return true;
            else
            {
                DisplayMarkCookingMenu(userChoice);
            }
            return true;
        }

        /// <summary>
        /// Display notification that the order is now marked as cooking and show the order details.
        /// </summary>
        /// <param name="userChoice"></param>
        private void DisplayMarkCookingMenu(int userChoice)
        {
            Order currentOrder = currentListOrder[userChoice];
            currentOrder.UpdateStatus(OrderStatus.Cooking);
            CmdLineUI.DisplayMessage($"Order #{currentOrder.Number} is now marked as cooking. Please prepare the order, then mark it as finished cooking:");         
            CmdLineUI.DisplayListItem(currentOrder);
        }

        /// <summary>
        /// This method generates a list of current orders that have been placed and are ready to be started cooking.
        /// </summary>
        private void GenerateCurrentListOrder()
        {
            foreach (var order in client.GetRestaurant().GetListOrder())
            {
                if (order.Status == OrderStatus.Ordered)
                {
                    currentListOrder.Add(order);
                }
            }
        }
    }
}
