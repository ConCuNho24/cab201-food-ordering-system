using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the finish cooking order menu for cooks in the Arriba Eats application.
    /// </summary>
    internal class FinishCookingOrderMenu
    {
        private Client client;
        private List<Order> currentListOrder = new List<Order>();

        /// <summary>
        /// Constructor for the FinishCookingOrderMenu class.
        /// </summary>
        /// <param name="client"></param>
        public FinishCookingOrderMenu(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// This method runs the Finish Cooking Order menu, allowing the user to select an order that has been prepared and mark it as cooked.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            GenerateCurrentListOrder();

            const string HEADER_STR = ("Select an order once you have finished preparing it:");
            int lastOption = currentListOrder.Count;

            /// Displaying the list of current orders that are being cooked and return the user's choice
            int userChoice = CmdLineUI.GetChoiceFromListOption(currentListOrder, 
                                        order => $"Order #{order.Number} for {order.GetCustomerName()}", HEADER_STR);


            if (userChoice == lastOption) return true;
            else
            {
                MarkCookedMenu(userChoice);
            }
            return true;
        }

        /// <summary>
        /// This method generates a list of current orders that are being cooked.
        /// </summary>
        private void GenerateCurrentListOrder()
        {
            foreach (var order in client.GetRestaurant().GetListOrder())
            {
                if (order.Status == OrderStatus.Cooking)
                {
                    currentListOrder.Add(order);
                }
            }
        }

        /// <summary>
        /// This method marks the selected order as cooked and displays information
        /// </summary>
        /// <param name="userChoice">Mark the delivevery base on user choice</param>
        private void MarkCookedMenu(int userChoice)
        {
            Order currentOrder = currentListOrder[userChoice];
            CmdLineUI.DisplayMessage($"Order #{currentOrder.Number} is now ready for collection.");

            currentOrder.UpdateStatus(OrderStatus.Cooked);
            DisplayExtraInfo(currentOrder);
            
        }

        /// <summary>
        /// This method displays additional information about the order, such as the deliverer's status and licence plate.
        /// </summary>
        /// <param name="currentOrder"></param>
        private void DisplayExtraInfo(Order currentOrder)
        {
            if (!currentOrder.isAssigned) // Check if the order has a deliverer assigned
            {
                CmdLineUI.DisplayMessage("No deliverer has been assigned yet.");
                return;
            }

            if (currentOrder.isDelivererArrived == false) //Check if the deliverer has arrived at the restaurant
            {
                CmdLineUI.DisplayMessage($"The deliverer with licence plate {currentOrder.GetDelivererPlate()} will be arriving soon to collect it.");
            }
            else
            {
                CmdLineUI.DisplayMessage($"Please take it to the deliverer with licence plate {currentOrder.GetDelivererPlate()}, who is waiting to collect it.");
            }
        }

    }
}
