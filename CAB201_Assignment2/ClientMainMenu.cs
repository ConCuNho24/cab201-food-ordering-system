using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the main menu for clients in the Arriba Eats application.
    /// </summary>
    internal class ClientMainMenu
    {
        /// <summary>
        /// These are the strings and integers used for the menu options in the client main menu.
        /// </summary>
        const string MENU_HEADER_STR = "Please make a choice from the menu below:";
        const string DISPLAY_STR = "Display your user information";
        const string ADD_ITEM_STR = "Add item to restaurant menu";
        const string SEE_ORDER_STR = "See current orders";
        const string START_COOKING_STR = "Start cooking order";
        const string FINISH_COOKING_STR = "Finish cooking order";
        const string HANDLE_DELIVERER_STR = "Handle deliverers who have arrived";
        const string LOG_OUT_STR = "Log out";
        const int DISPLAY_INT = 0, ADD_ITEM_INT = 1, SEE_ORDER_INT = 2, START_COOKING_INT = 3, FINISH_COOKING_INT = 4, HANDLE_DELIVERER_INT = 5, LOG_OUT_INT = 6;


        private Client client;

        /// <summary>
        /// Constructor for the ClientMainMenu class.
        /// </summary>
        /// <param name="client"></param>
        public ClientMainMenu(Client client)
        {
            this.client = client;  // Initialize the client object
        }

        /// <summary>
        /// This method runs the client main menu, allowing the user to select options related to their restaurant and orders.
        /// </summary>
        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = DisplayClientMainMenu();
            }
        }

        /// <summary>
        /// This method displays the client main menu and returns a boolean value indicating whether to continue or not.
        /// </summary>
        /// <returns></returns>
        private bool DisplayClientMainMenu()
        {
            
            int userChoice = CmdLineUI.GetOption(MENU_HEADER_STR, DISPLAY_STR, ADD_ITEM_STR, SEE_ORDER_STR, START_COOKING_STR, FINISH_COOKING_STR, HANDLE_DELIVERER_STR, LOG_OUT_STR);

            switch (userChoice)
            {
                case DISPLAY_INT: // Display user information
                    UserMenuInfo userMenuInfo = new UserMenuInfo(client);
                    return userMenuInfo.Run();
                case ADD_ITEM_INT: // Add item to restaurant menu
                    AddItemMenu addItemMenu = new AddItemMenu(client);
                    return addItemMenu.Run();
                case SEE_ORDER_INT: // See current orders
                    SeeCurrentOrderMenu seeCurrentOrderMenu = new SeeCurrentOrderMenu(client);
                    return seeCurrentOrderMenu.Run();
                case START_COOKING_INT:// Start cooking order
                    StartCookingMenu startCookingMenu = new StartCookingMenu(client);
                    return startCookingMenu.Run();
                case FINISH_COOKING_INT: // Finish cooking order
                    FinishCookingOrderMenu finishCookingOrderMenu = new FinishCookingOrderMenu(client);
                    return finishCookingOrderMenu.Run();
                case HANDLE_DELIVERER_INT: // Handle deliverers who have arrived
                    HandleDelivererMenu handleDelivererMenu = new HandleDelivererMenu(client);
                    return handleDelivererMenu.Run();
                case LOG_OUT_INT: // Log out
                    CmdLineUI.DisplayMessage("You are now logged out.");
                    return false;
            }
            return false;
        }
            
    }
}
