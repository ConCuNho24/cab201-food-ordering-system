using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the pick order menu for deliverers in the Arriba Eats application.
    /// </summary>
    internal class PickOrderMenu
    {
        private Deliverer deliverer;
        private Order currentOrder;

        /// <summary>
        /// Constructor for the PickOrderMenu class.
        /// </summary>
        /// <param name="deliverer">current deliverer</param>
        public PickOrderMenu(Deliverer deliverer)
        {
            this.deliverer = deliverer;
            currentOrder = deliverer.GetCurrentOrder();
        }

        /// <summary>
        /// This method runs the Pick Order menu
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (!deliverer.CurentlyHavingOrder())
            {
                CmdLineUI.DisplayMessage("You have not yet accepted an order.");
                return true;
            }
            else
            {
                return ProcessStatusOrder();
            }
        }

        /// <summary>
        /// This method processes the status of the current order for the deliverer.
        /// </summary>
        /// <returns></returns>
        private bool ProcessStatusOrder()
        {
            if (currentOrder.Status == OrderStatus.BeingDelivered)
            {
                CmdLineUI.DisplayMessage("You have already picked up this order.");
                return true;
            }
            else if (currentOrder.isDelivererArrived == true)
            {
                CmdLineUI.DisplayMessage("You already indicated that you have arrived at this restaurant.");
                return true;
            }
            else
            {
                NoticeToDeliverer();
                return true;
            }

        }

        /// <summary>
        /// This method notifies the deliverer that they have arrived at the restaurant to pick up the order.
        /// </summary>
        private void NoticeToDeliverer()
        {
            // notify the restaurant that they have arrived at the restaurant
            CmdLineUI.DisplayMessage($"Thanks. We have informed {currentOrder.GetRestaurantName()} that you have arrived and are ready to pick up order #{currentOrder.Number}.");
            CmdLineUI.DisplayMessage("Please show the staff this screen as confirmation.");
            currentOrder.MarkDelivererArrived();

            // check if the order is still being prepared
            if (currentOrder.Status == OrderStatus.Ordered || currentOrder.Status == OrderStatus.Cooking)
            {
                CmdLineUI.DisplayMessage("The order is still being prepared, so please wait patiently until it is ready.");
            }

            // tell the deliverer to pick up the order
            string customerLocation = currentOrder.GetCustomerLocation().ToString();
            CmdLineUI.DisplayMessage($"When you have the order, please deliver it to {currentOrder.GetCustomerName()} at {customerLocation}.");
        }

        

    }
}
