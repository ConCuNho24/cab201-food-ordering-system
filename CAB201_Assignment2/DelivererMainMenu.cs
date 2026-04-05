using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the main menu for deliverers in the Arriba Eats application.
    /// </summary>
    internal class DelivererMainMenu
    {
        /// <summary>
        /// These are constants for the strings to be displayed in the deliverer main menu.
        /// </summary>
        const string MENU_HEADER_STR = "Please make a choice from the menu below:";
        const string USER_INFO_STR = "Display your user information";
        const string ORDER_LIST_STR = "List orders available to deliver";
        const string PICK_ORDER_STR = "Arrived at restaurant to pick up order";
        const string MARK_DELIVERY_STR = "Mark this delivery as complete";
        const string LOGOUT_STR = "Log out";
        const int USER_INFO_INT = 0, ORDER_LIST_INT = 1, PICK_ORDER_INT = 2, MARK_DELIVERY_INT = 3, LOGOUT_INT = 4;

        private Deliverer deliverer;

        /// <summary>
        /// Constructor for the DelivererMainMenu class.
        /// </summary>
        /// <param name="deliverer"></param>
        public DelivererMainMenu(Deliverer deliverer)
        {
            this.deliverer = deliverer;
        }

        /// <summary>
        /// This method runs the deliverer main menu, allowing the deliverer to interact with the application.
        /// </summary>
        public void Run()
        {

            bool keepGoing = true;  
            while (keepGoing)
            {
                keepGoing = DisplayDelivererMainMenu();
            }
        }

        /// <summary>
        /// This method displays the main menu for the deliverer and returns a boolean value indicating whether to continue or not.
        /// </summary>
        /// <returns></returns>
        private bool DisplayDelivererMainMenu() 
        {
            int userChoice = CmdLineUI.GetOption(MENU_HEADER_STR, USER_INFO_STR, ORDER_LIST_STR, PICK_ORDER_STR, MARK_DELIVERY_STR, LOGOUT_STR);
            switch (userChoice)
            {
                case USER_INFO_INT: /// display user information
                    UserMenuInfo userMenuInfo = new UserMenuInfo(deliverer);
                    return userMenuInfo.Run();
                case ORDER_LIST_INT:/// List available orders to deliver 
                    AvailableOrdersMenu availableOrdersMenu = new AvailableOrdersMenu(deliverer);
                    return availableOrdersMenu.Run();
                case PICK_ORDER_INT:/// Arrived at restaurant to pick up order
                    PickOrderMenu pickOrderMenu = new PickOrderMenu(deliverer);
                    return pickOrderMenu.Run();
                case MARK_DELIVERY_INT:/// Mark delivery as complete
                    MarkDeliveryMenu markDeliveryMenu = new MarkDeliveryMenu(deliverer);
                    return markDeliveryMenu.Run();
                case LOGOUT_INT:/// Log out
                    CmdLineUI.DisplayMessage("You are now logged out.");
                    return false;
            }
            return false;
        }
    }
}
