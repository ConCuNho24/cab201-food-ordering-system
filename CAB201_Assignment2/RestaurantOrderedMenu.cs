using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the restaurant ordered menu of the Arriba Eats application.
    /// </summary>
    internal class RestaurantOrderedMenu
    {
        /// <summary>
        /// These are the strings to be displayed in the restaurant ordered menu
        /// </summary>
        const string RES_LIST_HEADER = "How would you like the list of restaurants ordered?";
        const string ALPHABETICAL_STR = "Sorted alphabetically by name";
        const string DISTANCE_STR = "Sorted by distance";
        const string STYLE_STR = "Sorted by style";
        const string RATING_STR = "Sorted by average rating";
        const string BACK_STR = "Return to the previous menu";
        const int ALPHABETICAL_INT = 0, DISTANCE_INT = 1, STYLE_INT = 2, RATING_INT = 3, BACK_INT = 4;


        private Customer customer;
        private List<Restaurant> sortedListRestaurant;
        private Restaurant chosenRestaurant;

        /// <summary>
        /// Constructor for the RestaurantOrderedMenu class.
        /// </summary>
        /// <param name="customer"></param>
        public RestaurantOrderedMenu (Customer customer)
        {
            this.customer = customer;
            sortedListRestaurant = RestaurantRepository.GetCurrentListRestaurant();
        }

        /// <summary>
        /// This method runs the restaurant ordered menu
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            int userChoice = CmdLineUI.GetOption(RES_LIST_HEADER, ALPHABETICAL_STR, DISTANCE_STR, STYLE_STR, RATING_STR, BACK_STR);
            if (userChoice == BACK_INT) return true; /// Return to the previous menu
            GenerateSortedRestaurantList(userChoice);

            DisplaySortedRestaurant(customer, sortedListRestaurant);
            
            return true;
        }

        /// <summary>
        /// This method generates a sorted list of restaurants based on the user's choice.
        /// </summary>
        /// <param name="userChoice"></param>
        private void GenerateSortedRestaurantList(int userChoice)
        {
            switch (userChoice)
            {
                case ALPHABETICAL_INT:
                    sortedListRestaurant = RestaurantRepository.SortByAlphabet(sortedListRestaurant);
                    break;
                case DISTANCE_INT:
                    sortedListRestaurant = RestaurantRepository.SortByDistance(customer, sortedListRestaurant);
                    break;
                case STYLE_INT:
                    sortedListRestaurant = RestaurantRepository.SortByStyle(sortedListRestaurant);
                    break;
                case RATING_INT:
                    sortedListRestaurant = RestaurantRepository.SortByRating(sortedListRestaurant);
                    break;
            }
        }

        /// <summary>
        /// This method displays the sorted list of restaurants and allows the user to choose one to order from.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="ListRestaurant"></param>
        private void DisplaySortedRestaurant(Customer customer, List<Restaurant> ListRestaurant)
        {

            CmdLineUI.DisplayMessage("You can order from the following restaurants:");
            CmdLineUI.DisplayMessage("   Restaurant Name       Loc    Dist  Style       Rating" + "\n");

            int currentOption = 1;

            foreach (var restaurant in ListRestaurant)
            {   
                ShowRestaurantOption(currentOption, restaurant);
                currentOption++;
            }

            CmdLineUI.DisplayMessage($"{currentOption}: Return to the previous menu");
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {currentOption}:");
            
            int userChoice = CmdLineUI.GetChoice();

            int ReturnOption = ListRestaurant.Count;

            if (userChoice == ReturnOption) return;
            else
            {
                chosenRestaurant = ListRestaurant[userChoice];
                RunChosenRestaurantMenu(chosenRestaurant);
            }
            
        }

        /// <summary>
        /// This method runs the menu for the chosen restaurant, allowing the user to place an order or view reviews.
        /// </summary>
        /// <param name="restaurant">Chosen Restaurant</param>
        private void RunChosenRestaurantMenu(Restaurant restaurant)
        {
            string OPTION_HEADER = $"Placing order from {restaurant.Name}.";
            CmdLineUI.DisplayMessage(OPTION_HEADER);

            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = DisplayChosenRestaurantMenu(restaurant);
            }
        }

        /// <summary>
        /// This method displays the restaurant option in the list of restaurants ordered.
        /// </summary>
        /// <param name="index">option number</param>
        /// <param name="restaurant">current restaurant</param>
        private void ShowRestaurantOption(int index, Restaurant restaurant)
        {
           
            int distance = restaurant.location.DistanceTo(customer.location);
            CmdLineUI.DisplayMessage($"{index}: {restaurant.Name,-20} {restaurant.location.ToString()}  {distance,5}  {restaurant.Style,-10}  {restaurant.GetAverageRatingString()}");
        }

        /// <summary>
        /// This method displays the menu for the chosen restaurant, allowing the user to see the menu and place an order or view reviews.
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        private bool DisplayChosenRestaurantMenu(Restaurant restaurant)
        {
            
            const string RESTAURANT_MENU_STR = "See this restaurant's menu and place an order";
            const string RESTAURANT_REVIEW_STR = "See reviews for this restaurant";
            const string BACK_STR = "Return to main menu";
            const int RESTAURANT_MENU_INT = 0, RESTAURANT_REVIEW_INT = 1, BACK_INT = 2;
            int userChoice = CmdLineUI.GetOption(null, RESTAURANT_MENU_STR, RESTAURANT_REVIEW_STR, BACK_STR);

            switch (userChoice)
            {
                case RESTAURANT_MENU_INT:
                    OrderMenu orderMenu = new OrderMenu(customer, restaurant);
                    return orderMenu.Run();
                case RESTAURANT_REVIEW_INT:
                    ReviewMenu reviewMenu = new ReviewMenu(restaurant);
                    return reviewMenu.Run();
                case BACK_INT:
                    return false;
            }
            return true;

        }
    }
}
