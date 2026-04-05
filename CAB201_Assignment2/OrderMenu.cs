using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for managing the order menu in the Arriba Eats application.
    /// </summary>
    internal class OrderMenu
    {   
        private Customer customer;
        private Restaurant restaurant;
        private int currentOrderNumber = OrderRepository.GetCurrentNumber();
        private double currentTotalPrice = 0.0;
        private bool ordering = true;
        private Dictionary<string, int> OrderedItems = new Dictionary<string, int>();
        private List<MenuItem> currentMenuList;

        /// <summary>
        /// Constructor for the OrderMenu class.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="restaurant"></param>
        public OrderMenu(Customer customer, Restaurant restaurant)
        {
            this.customer = customer;
            this.restaurant = restaurant;
            currentMenuList = restaurant.GetMenuList();
        }

        /// <summary>
        /// This method runs the Order menu, allowing the user to select items from the restaurant's menu and place an order.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            int completeOrderOption = currentMenuList.Count;
            int cancelOrderOption = currentMenuList.Count + 1;

            while (ordering)
            {
                DisplayOptions(currentTotalPrice, restaurant);

                int userChoice = CmdLineUI.GetChoice();

                if (userChoice == completeOrderOption)
                {
                    ordering = CompleteOrder();
                }
                else if (userChoice == cancelOrderOption)
                {
                    ordering = false;
                }
                else
                {
                    ordering = AddingToOrder(userChoice);
                }
            }

            return true;
        }

        /// <summary>
        /// This method displays the current order total and the available options for the user to select from the restaurant's menu.
        /// </summary>
        /// <param name="currentPrice">current price</param>
        /// <param name="restaurant">current restaurant</param>
        private void DisplayOptions(double currentPrice, Restaurant restaurant)
        {
            CmdLineUI.DisplayMessage($"Current order total: ${currentPrice:F2}");

            int currentOption = 1;

            foreach (var item in currentMenuList)
            {
                CmdLineUI.DisplayMessage($"{currentOption}:   {item.Price,7:C2}  {item.Name}");
                currentOption++;
            }
            CmdLineUI.DisplayMessage($"{currentOption}: Complete order");
            CmdLineUI.DisplayMessage($"{currentOption + 1}: Cancel order");
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {currentOption + 1}:");
        }

        /// <summary>
        /// This method completes the order by displaying the order number and processing the order with the OrderRepository.
        /// </summary>
        /// <returns></returns>
        private bool CompleteOrder()
        {
            CmdLineUI.DisplayMessage($"Your order has been placed. Your order number is #{currentOrderNumber}.");
            Order currentOrder = new Order(currentOrderNumber, customer, restaurant, currentTotalPrice, OrderedItems);
            OrderRepository.ProcessOrder(currentOrder, customer, restaurant);
            return false;
        }

        private bool AddingToOrder(int userChoice)
        {
            MenuItem item = currentMenuList[userChoice];
            CmdLineUI.DisplayMessage($"Adding {item.Name} to order.");
            CmdLineUI.DisplayMessage("Please enter quantity (0 to cancel):");

            int quantity = int.Parse(Console.ReadLine());
            if (quantity == 0) return true;
            UpdateCart(item, quantity);
            return true;
        }

        /// <summary>
        /// This method updates the cart by adding the selected item and its quantity to the order, updating the total price accordingly.
        /// </summary>
        /// <param name="item">current item</param>
        /// <param name="quantity"> quantity for that item</param>
        private void UpdateCart(MenuItem item, int quantity)
        {
            CmdLineUI.DisplayMessage($"Added {quantity} x {item.Name} to order.");
            if (OrderedItems.ContainsKey(item.Name))
            {
                OrderedItems[item.Name] += quantity;
            }
            else
            {
                OrderedItems.Add(item.Name, quantity);
            }
            currentTotalPrice += quantity * item.Price;
        }
    }
}
