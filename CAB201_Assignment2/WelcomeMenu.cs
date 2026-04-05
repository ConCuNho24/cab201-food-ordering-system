using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the welcome menu of the Arriba Eats application.
    /// </summary>
    internal class WelcomeMenu
    {
        /// <summary>
        /// This method runs the welcome menu
        /// </summary>
        public void Run()
        {
            DisplayWelcomeHeader();
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = DisplayWelcomeMenu();   
            }

        }

        /// <summary>
        /// Show the header/welcome message of the application
        /// </summary>
        private void DisplayWelcomeHeader()
        {
            CmdLineUI.DisplayMessage("Welcome to Arriba Eats!");
        }


        private bool DisplayWelcomeMenu()
        {   /// Below are the options for the welcome menu 
            const string OPTION_HEADER = "Please make a choice from the menu below:";
            const string LOGIN_STR = "Login as a registered user";
            const string REGISTER_STR = "Register as a new user";
            const string EXIT_STR = "Exit";
            const int LOGIN_INT = 0, REGISTER_INT = 1, EXIT_INT = 2;

            /// Get user's option based on the above options
            int userOption = CmdLineUI.GetOption(OPTION_HEADER, LOGIN_STR, REGISTER_STR, EXIT_STR);

            /// Based on the user's option, display the corresponding menu
            switch (userOption)
            {
                case LOGIN_INT:/// Go to login menu
                    return LoginMenu.Run(); 
                case REGISTER_INT: /// Go to register menu
                    return RegisterMenu.Run();  
                case EXIT_INT: /// exit the application
                    CmdLineUI.DisplayMessage("Thank you for using Arriba Eats!");
                    return false;
                default:
                    CmdLineUI.DisplayMessage("Invalid option. Please try again.");
                    return false;
            }
        }
    }
}
