using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This class provides a menu for registering a new user in the Arriba Eats application.
    /// </summary>
    internal class RegisterMenu
    {
        /// <summary>
        /// These are constants for the strings to be displayed in the register menu.
        /// </summary>
        const string OPTION_HEADER = "Which type of user would you like to register as?";
        const string CUSTOMER_STR = "Customer";
        const string DELIVERER_STR = "Deliverer";
        const string CLIENT_STR = "Client";
        const string BACK_STR = "Return to the previous menu";

        const int CUSTOMER_INT = 0, DELIVERER_INT = 1, CLIENT_INT = 2, BACK_INT = 3;

        /// <summary>
        /// This method runs the register menu, allowing the user to select a user type and register as a new user.
        /// </summary>
        /// <returns></returns>
        public static bool Run()
        {

            int userOption = CmdLineUI.GetOption(OPTION_HEADER, CUSTOMER_STR, DELIVERER_STR, CLIENT_STR, BACK_STR);   

            if (userOption == BACK_INT)
            {
                return true;
            }   
            else
            {
                User user = CreateUser(userOption);
                UserRepository.AddUser(user);
                CmdLineUI.DisplayMessage($"You have been successfully registered as a {user.GetType().Name.ToLower()}, {user.Name}!");
                return true;

            }
        }

        /// <summary>
        /// This method creates a new user based on the user's choice of user type (Customer, Deliverer, or Client).
        /// </summary>
        /// <param name="userOption">ioption number</param>
        /// <returns></returns>
        private static User CreateUser(int userOption)
        {
            /// This section validates the user's input for various fields such as name, age, email, phone number, and password.
            string userName = ValidateService.ValidateName();
            int userAge = ValidateService.ValidateAge();
            string userEmail = ValidateService.ValidateEmail();
            string userPhoneNumber = ValidateService.ValidatePhoneNumber();
            string userPassword = ValidateService.ValidatePassword();
            User user = null;

            /// This section creates a new user object based on the user's choice of user type.
            switch (userOption)
            {
                case CUSTOMER_INT: // Registetr as a Customer
                    Location location = ValidateService.ValidateLocation();
                    user = new Customer(userName, userAge, userEmail, userPhoneNumber, userPassword, location);
                    break;
                case DELIVERER_INT: // Register as a Deliverer
                    string userPlate = ValidateService.ValidatePlate();
                    user = new Deliverer(userName, userAge, userEmail, userPhoneNumber, userPassword, userPlate);
                    break;
                case CLIENT_INT: // Register as a Client
                    Restaurant restaurant = ValidateService.ValidateRestaurant();
                    user = new Client(userName, userAge, userEmail, userPhoneNumber, userPassword, restaurant);
                    RestaurantRepository.AddRestaurant(restaurant);
                    break;
            }
            return user;
        }

    }
}
