using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the rate restaurant menu for customers in the Arriba Eats application.
    /// </summary>
    internal class RateRestaurantMenu
    {
        private Customer customer;
        private List<Order> listUnratedOrder = new List<Order>();
        public RateRestaurantMenu(Customer customer)
        {
            this.customer = customer;
        }

        /// <summary>
        /// This method runs the Rate Restaurant menu
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            const string HEADER_STR = "Select a previous order to rate the restaurant it came from:";
            GenerateListUnratedOrder();

            int lastOption = listUnratedOrder?.Count ?? 0;

            int userChoice = CmdLineUI.GetChoiceFromListOption(listUnratedOrder,
                                        order => $"Order #{order.Number} from {order.GetRestaurantName()}", HEADER_STR);


            if (userChoice == lastOption) return true;

            Order chosenOrder = listUnratedOrder[userChoice];
            return DisplayUnratedOrder(chosenOrder);
        }

        /// <summary>
        /// This method displays the details of an unrated order and allows the user to rate it.
        /// </summary>
        /// <param name="UnRatedOrder">Order with no rating</param>
        /// <returns></returns>
        private bool DisplayUnratedOrder(Order UnRatedOrder)
        {
            string restaurantName = UnRatedOrder.GetRestaurantName();

            CmdLineUI.DisplayMessage($"You are rating order #{UnRatedOrder.Number} from {restaurantName}:");
            CmdLineUI.DisplayListItem(UnRatedOrder);
            
            int star = CmdLineUI.GetInt("Please enter a rating for this restaurant (1-5, 0 to cancel):");

            if (star == 0) return true;
            string comment = CmdLineUI.GetString("Please enter a comment to accompany this rating:");

            CmdLineUI.DisplayMessage($"Thank you for rating {restaurantName}.");
            
            Rating currentRating = new Rating(UnRatedOrder.GetCustomerName(), star, comment);
            UnRatedOrder.UpdateRating(currentRating);
            return true;

            
        }

        /// <summary>
        /// This method generates a list of unrated orders for the customer, which are orders that have been delivered but not yet rated.
        /// </summary>
        private void GenerateListUnratedOrder()
        {
            foreach (var order in customer.GetOrderList())
            {
                if (order.GetOrderRating() == null && order.Status == OrderStatus.Delivered)
                {
                    listUnratedOrder.Add(order);
                }
            }

        }

    }
}
