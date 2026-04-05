using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for marking order delivered
    /// </summary>
    internal class MarkDeliveryMenu
    {
        private Deliverer deliverer;
        private Order currentOrder;

        /// <summary>
        /// The constructor for the class
        /// </summary>
        /// <param name="deliverer">current deliverer</param>
        public MarkDeliveryMenu(Deliverer deliverer)
        {
            this.deliverer = deliverer;
            currentOrder = deliverer.GetCurrentOrder(); 
        }

        /// <summary>
        /// This is a method to run the menu
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (!deliverer.CurentlyHavingOrder()) /// Check if the deliverer has already accepted an order

            {
                CmdLineUI.DisplayMessage("You have not yet accepted an order.");
            }
            else if (currentOrder.Status != OrderStatus.BeingDelivered)  /// Check if the current order is being delivered
            {
                CmdLineUI.DisplayMessage("You have not yet picked up this order.");
            }
            else 
            {
                CmdLineUI.DisplayMessage("Thank you for making the delivery.");
                OrderRepository.ProcessMarkOrderDelivered(currentOrder, deliverer);
            }
            return true;
        }
    }
}
