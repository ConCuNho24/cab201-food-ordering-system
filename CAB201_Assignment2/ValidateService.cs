using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This class is used for validate input from user
    /// </summary>
    internal class ValidateService
    {
        /// <summary>
        /// Check Valid name
        /// </summary>
        /// <param name="name">Get the name from input</param>
        /// <returns></returns>
        private static bool IsValidName(string name)
        {
            const string NAME_REGEX = @"^(?=.*[a-zA-Z])[a-zA-Z\s'-]+$";
            
            return Regex.IsMatch(name, NAME_REGEX); /// Check whether match the name regex 
        }

        /// <summary>
        /// Validate name
        /// </summary>
        /// <returns></returns>
        public static string ValidateName()
        {
            while (true)
            {
                string name = CmdLineUI.GetString("Please enter your name:");

                if (IsValidName(name))
                {
                    return name;
                }
                else
                {
                    CmdLineUI.DisplayMessage("Invalid name.");
                }
            }
        }

        /// <summary>
        /// Validate age
        /// </summary>
        /// <returns></returns>
        public static int ValidateAge()
        {
            const int MIN_AGE = 18;
            const int MAX_AGE = 100;
            int age;
            while (true)
            {
                string input = CmdLineUI.GetString("Please enter your age (18-100):");

                if (int.TryParse(input, out age) && age >= MIN_AGE && age <= MAX_AGE) 
                {
                    return age;
                }
                else
                {
                    CmdLineUI.DisplayMessage("Invalid age.");
                }
            }
        }

        /// <summary>
        /// check valid email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static bool IsValidEmail(string email)
        {
            int atIndex = email.IndexOf('@');
            return atIndex > 0 &&
                   atIndex == email.LastIndexOf('@') &&
                   atIndex < email.Length - 1;
        }

        /// <summary>
        /// Validate email
        /// </summary>
        /// <returns></returns>
        public static string ValidateEmail()
        {
            while (true)
            {
                string email = CmdLineUI.GetString("Please enter your email address:");   

                if (!IsValidEmail(email))
                {
                    CmdLineUI.DisplayMessage("Invalid email address.");
                }
                else if (UserRepository.GetRegisteredEmailList().Contains(email))
                {
                    CmdLineUI.DisplayMessage("This email address is already in use.");
                }
                else
                {
                    return email; 
                }
            }
        }
        /// <summary>
        /// Check valid Phone number
        /// </summary>
        /// <param name="phoneNumber">Take phoneNumber input</param>
        /// <returns></returns>
        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            const string PHONE_REGEX = @"^0\d{9}$"; /// Phone number must start with 0 and have exactly 10 digits   
            // Check if it consists of exactly 10 digits and starts with 0
            return Regex.IsMatch(phoneNumber, PHONE_REGEX);
        }

        /// <summary>
        ///  Validate phone number
        /// </summary>
        /// <returns></returns>
        public static string ValidatePhoneNumber()
        {
            while (true)
            {
                string phoneNumber = CmdLineUI.GetString("Please enter your mobile phone number:");

                if (!IsValidPhoneNumber(phoneNumber))
                {
                    CmdLineUI.DisplayMessage("Invalid phone number.");
                }
                else
                {
                    return phoneNumber; 
                }
            }
            
        }

        /// <summary>
        /// Check valid password
        /// </summary>
        /// <param name="password">take password</param>
        /// <returns></returns>
        private static bool IsValidPassword(string password)
        {
            const string HAS_NUMBER_REGEX = @"\d"; /// Check if it has number
            const string HAS_LOWER_REGEX = @"[a-z]"; /// Check if it has lowercase  
            const string HAS_UPPER_REGEX = @"[A-Z]"; /// Check if it has uppercase  
            if (password.Length < 8)
                return false;

            bool hasNumber = Regex.IsMatch(password, HAS_NUMBER_REGEX); 
            bool hasLower = Regex.IsMatch(password, HAS_LOWER_REGEX); 
            bool hasUpper = Regex.IsMatch(password, HAS_UPPER_REGEX); 

            return hasNumber && hasLower && hasUpper;
        }

        /// <summary>
        /// Validate password
        /// </summary>
        /// <returns></returns>
        public static string ValidatePassword()
        {
            while (true)
            {
                CmdLineUI.DisplayMessage("Your password must:");
                CmdLineUI.DisplayMessage("- be at least 8 characters long");
                CmdLineUI.DisplayMessage("- contain a number");
                CmdLineUI.DisplayMessage("- contain a lowercase letter");
                CmdLineUI.DisplayMessage("- contain an uppercase letter");
                CmdLineUI.DisplayMessage("Please enter a password: ");
                string password = CmdLineUI.GetString();

                if (!IsValidPassword(password))
                {
                    CmdLineUI.DisplayMessage("Invalid password.");
                    continue; 
                }

                string confirmPassword = CmdLineUI.GetString("Please confirm your password: ");
                if (password != confirmPassword)
                {
                    CmdLineUI.DisplayMessage("Passwords do not match.");
                    continue; 
                }

                return password; 
            }
        }

        /// <summary>
        /// Check valid plate for the deliverer
        /// </summary>
        /// <param name="licencePlate">Take plate from input</param>
        /// <returns></returns>
        private static bool IsValidLicencePlate(string licencePlate)
        {
            const int MIN_CHAR = 1;
            const int MAX_CHAR = 8;
            const string DELIVERER_REGEX = @"^[A-Z0-9 ]+$";

            if (string.IsNullOrWhiteSpace(licencePlate)) return false; /// Check spcae
            if (licencePlate.Length < MIN_CHAR || licencePlate.Length > MAX_CHAR) /// Check length
                return false;

            if (!Regex.IsMatch(licencePlate, DELIVERER_REGEX)) /// Check match the regex
                return false;

            if (licencePlate.Trim().Length == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Validate plate for the deliverer
        /// </summary>
        /// <returns></returns>
        public static string ValidatePlate()
        {
            while (true)
            {
                string plate = CmdLineUI.GetString("Please enter your licence plate: ");
                if (IsValidLicencePlate(plate))
                {
                    return plate;
                }
                else
                {
                    CmdLineUI.DisplayMessage("Invalid licence plate.");
                }
            }
        }

        /// <summary>
        /// Check valid location
        /// </summary>
        /// <param name="input"></param>
        /// <param name="x">take X coordinate</param>
        /// <param name="y">take Y coordinate</param>
        /// <returns></returns>
        private static bool IsValidLocation(string input, out int x, out int y)
        {
            x = 0;
            y = 0;

            if (string.IsNullOrWhiteSpace(input)) return false;
            string[] parts = input.Split(',');
            if (parts.Length != 2) return false;

            return int.TryParse(parts[0].Trim(), out x) && int.TryParse(parts[1].Trim(), out y);
        }

        /// <summary>
        /// Validate location input from the user
        /// </summary>
        /// <returns></returns>
        public static Location ValidateLocation()
        {
            int x, y;
            while (true)
            {
                string input = CmdLineUI.GetString("Please enter your location (in the form of X,Y):");

                if (IsValidLocation(input, out x, out y))
                {
                    return new Location(x, y); 
                }
                else
                {
                    CmdLineUI.DisplayMessage("Invalid location.");
                }
            }

        }

        /// <summary>
        /// Check if the restaurant name is valid
        /// </summary>
        /// <param name="input">restaurant name input</param>
        /// <returns></returns>
        private static bool IsValidRestaurantName(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Validate restaurant information input from the user
        /// </summary>
        /// <returns></returns>
        public static Restaurant ValidateRestaurant()
        {
            while (true)
            {
                string restaurantName = CmdLineUI.GetString("Please enter your restaurant's name:");

                if (IsValidRestaurantName(restaurantName))
                {
                    const string OPTION_HEARDER = "Please select your restaurant's style:"; 
                    const string ITALIAN_STR = "Italian";
                    const string FRENCH_STR = "French";
                    const string CHINESE_STR = "Chinese";
                    const string JAPANESE_STR = "Japanese";
                    const string AMERICAN_STR = "American";
                    const string AUSTRALIAN_STR = "Australian";

                    int userOption = CmdLineUI.GetOption(OPTION_HEARDER, ITALIAN_STR, FRENCH_STR, CHINESE_STR, JAPANESE_STR, AMERICAN_STR, AUSTRALIAN_STR); 

                    RestaurantStyle style = (RestaurantStyle)userOption;

                    Location location = ValidateLocation();

                    return new Restaurant(restaurantName, style, location);
                }
                else
                {
                    CmdLineUI.DisplayMessage("Invalid restaurant name.");
                }
            }

        }

        /// <summary>
        /// Check if the price is valid
        /// </summary>
        /// <param name="input">price input</param>
        /// <param name="price">price return</param>
        /// <returns></returns>
        private static bool IsValidPrice(string input, out double price)
        {
            const double MIN_PRICE = 0.00;
            const double MAX_PRICE = 999.99;  

            bool valid = double.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out price);
            return valid && price >= MIN_PRICE && price <= MAX_PRICE;
        }

        /// <summary>
        /// Validate the price of a new item to be added to the restaurant's menu.
        /// </summary>
        /// <returns></returns>
        public static double ValidatePrice()
        {
            double price;

            while (true)
            {
                string input = CmdLineUI.GetString("Please enter the price of the new item (without the $):");

                if (IsValidPrice(input, out price))
                {
                    return price;
                }
                else
                {
                    CmdLineUI.DisplayMessage("Invalid price.");
                }
            }
        }

    }
}
