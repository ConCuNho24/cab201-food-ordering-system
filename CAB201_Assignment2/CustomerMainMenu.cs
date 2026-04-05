using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying customer main menu of the Arriba Eats application.
    /// </summary>

    internal class CustomerMainMenu
    {
        /// <summary>
        /// below are the string to be displayed in the customer main menu
        /// </summary>
        const string OPTION_HEADER = "Please make a choice from the menu below:";
        const string USER_INFO_STR = "Display your user information";
        const string RESTAURANT_LIST_STR = "Select a list of restaurants to order from";
        const string ORDER_STATUS_STR = "See the status of your orders";
        const string RATE_RESTAURANT_STR = "Rate a restaurant you've ordered from";
        const string LOGOUT_STR = "Log out";
        const int USER_INFO_INT = 0, RESTAURANT_LIST_INT = 1, ORDER_STATUS_INT = 2, RATE_RESTAURANT_INT = 3, LOGOUT_INT = 4;

        private Customer customer; /// The customer object that is currently logged in

        /// <summary>
        /// Constructor for the CustomerMainMenu class.
        /// </summary>
        public CustomerMainMenu(Customer customer)
        {
            this.customer = customer; /// Initialize the customer object
        }
        /// <summary>
        /// This method runs the customer main menu
        /// </summary>
        /// <param name="customer"></param>
        public void Run()
        {   
            bool keepGoing = true;
            while (keepGoing) /// Keep looping until the user chooses to log out
            {
                keepGoing = DisplayMainMenu();
            }
        }
        /// <summary>
        /// This method displays the main menu for the customer and returns a boolean value indicating whether to continue or not.
        /// </summary>
        /// <returns></returns>
        private bool DisplayMainMenu()
        {
            int userOption = CmdLineUI.GetOption(OPTION_HEADER, USER_INFO_STR, RESTAURANT_LIST_STR, ORDER_STATUS_STR, RATE_RESTAURANT_STR, LOGOUT_STR);

            /// Based on the user's option, display the corresponding menu
            switch (userOption)
            {
                case USER_INFO_INT: /// display user information
                    UserMenuInfo userMenuInfo = new UserMenuInfo(customer);
                    return userMenuInfo.Run();

                case RESTAURANT_LIST_INT: /// display the list of restaurants
                    RestaurantOrderedMenu restaurantOrderedMenu = new RestaurantOrderedMenu(customer);
                    return restaurantOrderedMenu.Run();

                case ORDER_STATUS_INT: /// display the status of the orders
                    StatusMenu statusMenu = new StatusMenu(customer);
                    return statusMenu.Run();

                case RATE_RESTAURANT_INT: /// rate a restaurant
                    RateRestaurantMenu rateRestaurantMenu = new RateRestaurantMenu(customer);
                    return rateRestaurantMenu.Run();

                case LOGOUT_INT: /// log out the user
                    CmdLineUI.DisplayMessage("You are now logged out.");
                    return false;
            }
            return false;
        }
    }
}
