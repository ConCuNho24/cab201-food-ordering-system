using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// THis is a class for displaying the login menu of the Arriba Eats application.
    /// </summary>
    internal class LoginMenu
    {

        /// <summary>
        /// This method runs the login menu
        /// </summary>
        /// <returns></returns>
        public static bool Run()
        {
            /// User enter email
            string userLoginEmail = CmdLineUI.GetString("Email: ");

            /// User enter password
            string userLoginPassword = CmdLineUI.GetString("Password: ");

            /// Authenticate and process the login
            User user = UserRepository.Authenticate(userLoginEmail, userLoginPassword);
            ProcessLogin(user);

            return true;
        }

        /// <summary>
        /// This method processes the login of a user.
        /// </summary>
        /// <param name="user">Registered User</param>
        public static void ProcessLogin(User user)
        {
            if (user == null) ///if the user is null, it means the email or password is incorrect
            {
                CmdLineUI.DisplayMessage("Invalid email or password.");
                return;
            }

            /// If the user is not null, Continue to the main menu
            CmdLineUI.DisplayMessage($"Welcome back, {user.Name}!");

            // check the type of user and display the corresponding main menu
            if (user is Customer customer) 
            {
                CustomerMainMenu customerMainMenu = new CustomerMainMenu(customer); 
                customerMainMenu.Run();
            }
            else if (user is Deliverer deliverer)
            {
                DelivererMainMenu delivererMainMenu = new DelivererMainMenu(deliverer);
                delivererMainMenu.Run();   
            }
            else if (user is Client client)
            {
                ClientMainMenu clientMainMenu = new ClientMainMenu(client);
                clientMainMenu.Run();
            }     
        }


    }
}
