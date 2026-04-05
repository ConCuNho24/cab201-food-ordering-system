using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the Add Item menu for restaurant owners in the Arriba Eats application.
    /// </summary>
    internal class AddItemMenu
    {
        private Client client;
        private Restaurant currentRestaurant;
        private List<MenuItem> menuList;

        /// <summary>
        /// Constructor for the AddItemMenu class.
        /// </summary>
        /// <param name="client"></param>
        public AddItemMenu(Client client)
        {
            this.client = client;
            currentRestaurant = client.GetRestaurant();
            menuList = currentRestaurant.GetMenuList(); 
        }

        /// <summary>
        /// This method runs the Add Item menu, allowing the user to add a new item to the restaurant's menu.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            ShowCurrentMenu(); /// Display the current menu items.
            ProcessAddItem(); /// Process the addition of a new item to the menu.
            return true;
        }

        /// <summary>
        /// This method displays the current menu items of the restaurant.
        /// </summary>
        private void ShowCurrentMenu()
        {
            const string CURRENT_MENU_STR = "This is your restaurant's current menu:";
            CmdLineUI.DisplayMessage(CURRENT_MENU_STR);
            if (menuList.Count > 0)
            {
                foreach (var item in menuList)
                {
                    CmdLineUI.DisplayMessage($"${item.Price:F2} {item.Name}");
                }
            }
        }

        /// <summary>
        /// This method processes the addition of a new item to the restaurant's menu.
        /// </summary>
        private void ProcessAddItem()
        {
            // Enter name of the item 
            const string ENTER_NAME_STR = "Please enter the name of the new item (blank to cancel):";
            string itemName = CmdLineUI.GetString(ENTER_NAME_STR);

            if (itemName == "") return;

            // Enter and validate the price of the item
            double price = ValidateService.ValidatePrice(); 

            MenuItem currentItem = new MenuItem(itemName, price);

            currentRestaurant.AddToMenu(currentItem);/// Add the new item to the restaurant's menu.

            CmdLineUI.DisplayMessage($"Successfully added {itemName} (${price:F2}) to menu.");

        }
    }
}
