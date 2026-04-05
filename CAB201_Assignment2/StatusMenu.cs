using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CAB201_Assignment2.Order;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the status of all orders placed by a customer in the Arriba Eats application.
    /// </summary>
    internal class StatusMenu
    {
        private Customer customer;
        private List<Order> currentListOrder;

        /// <summary>
        /// Constructor for the StatusMenu class.
        /// </summary>
        /// <param name="customer"></param>
        public StatusMenu(Customer customer)
        {
            this.customer = customer;
            currentListOrder = customer.GetOrderList();
        }

        /// <summary>
        /// This method runs the Status menu, allowing the user to view the status of all their orders.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (customer.GetOrderList().Count == 0) CmdLineUI.DisplayMessage("You have not placed any orders.");
            else
            {
                ShowAllOrderStatus();
            }
            return true;
        }

        /// <summary>
        /// This method displays the status of all orders placed by the customer, including the order number, restaurant name, and status.
        /// </summary>
        private void ShowAllOrderStatus()
        {
            // loop each order in the customer's order list and display its status
            foreach (Order currentOrder in currentListOrder)
            {
                int orderNumber = currentOrder.Number;
                string restaurantName = currentOrder.GetRestaurantName();
                string orderStatus = currentOrder.GetStatusString();
                
                CmdLineUI.DisplayMessage($"Order #{orderNumber} from {restaurantName}: {orderStatus}");

                // if the order has been delivered, display the deliverer's name and licence plate
                if (currentOrder.Status == OrderStatus.Delivered)
                {
                    string delivererName = currentOrder.GetDelivererName();
                    string delivererPlate = currentOrder.GetDelivererPlate();
                    CmdLineUI.DisplayMessage($"This order was delivered by {delivererName} (licence plate: {delivererPlate})");
                }
                CmdLineUI.DisplayListItem(currentOrder);    
            }

        }
        
    }
}
