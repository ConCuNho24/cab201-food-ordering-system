using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the available orders menu for deliverers in the Arriba Eats application.
    /// </summary>
    internal class AvailableOrdersMenu
    {
        private Deliverer deliverer;
        private Location delivererLocation;
        private List<Order> AvailableListOrder = new List<Order>();

        /// <summary>
        /// Constructor for the AvailableOrdersMenu class.
        /// </summary>
        /// <param name="deliverer"></param>
        public AvailableOrdersMenu(Deliverer deliverer)
        {
            this.deliverer = deliverer;
        }

        /// <summary>
        /// This method runs the Available Orders menu, allowing the deliverer to select an order for delivery.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (deliverer.CurentlyHavingOrder())
            {
                CmdLineUI.DisplayMessage("You have already selected an order for delivery.");
                return true;
            }

            else
            {
                delivererLocation = ValidateService.ValidateLocation();
                GenerateAvailableOrdersMenu();
                ShowAllOptions();
                ProcessAssignOrder();
                return true;
            }
        }

        /// <summary>
        /// This method generates a list of available orders that can be assigned to the deliverer.
        /// </summary>
        private void GenerateAvailableOrdersMenu()
        {
            foreach (var order in OrderRepository.GetList())
            {
                if (order.isAssigned == false)
                {
                    AvailableListOrder.Add(order);
                }
            }
        }

        /// <summary>
        /// This method calculates the total distance for an order, which is the sum of the distance from the deliverer's location to the restaurant and from the restaurant to the customer's location.
        /// </summary>
        /// <param name="order">Current order</param>
        /// <returns></returns>
        private int GetTotalDistance(Order order)
        {
            Location restaurantLocation = order.GetRestaurantLocation();
            Location customerLocation = order.GetCustomerLocation();
            return delivererLocation.DistanceTo(restaurantLocation) + restaurantLocation.DistanceTo(customerLocation);
        }

        /// <summary>
        /// This method displays all available options for the deliverer to choose from
        /// </summary>
        private void ShowAllOptions()
        {
            CmdLineUI.DisplayMessage($"The following orders are available for delivery. Select an order to accept it:");
            CmdLineUI.DisplayMessage("   Order  Restaurant Name       Loc    Customer Name    Loc    Dist");

            int currentOption = 1;

            foreach (var order in AvailableListOrder)
            {
                ShowEachOption(currentOption, order);
                currentOption++;
            }
            CmdLineUI.DisplayMessage($"{currentOption}: Return to the previous menu");
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {currentOption}:");

        }

        /// <summary>
        /// This method displays each option available 
        /// </summary>
        /// <param name="currentOption">current option number</param>
        /// <param name="order">current number</param>
        private void ShowEachOption(int currentOption, Order order)
        {
            int totalDistance = GetTotalDistance(order);
            int orderNumber = order.Number;
            string restaurantName = order.GetRestaurantName();
            string restaurantLocation = order.GetRestaurantLocation().ToString();
            string customerName = order.GetCustomerName();
            string customerLocation = order.GetCustomerLocation().ToString();

            CmdLineUI.DisplayMessage($"{currentOption,-3}: {orderNumber,-6} {restaurantName,-20} {restaurantLocation,-6} {customerName,-15} {customerLocation,-6} {totalDistance}");

        }

        /// <summary>
        /// This method processes the order assignment based on the user's choice from the available orders.
        /// </summary>
        private void ProcessAssignOrder()
        {
            int userChoice = CmdLineUI.GetChoice();
            Order chosenOrder = AvailableListOrder[userChoice];

            chosenOrder.Assign(deliverer);
            deliverer.UpdateCurrentOrder(chosenOrder);

            CmdLineUI.DisplayMessage($"Thanks for accepting the order. Please head to {chosenOrder.GetRestaurantName()} at {chosenOrder.GetRestaurantLocation().ToString()} to pick it up.");
        }
       
    }
}
