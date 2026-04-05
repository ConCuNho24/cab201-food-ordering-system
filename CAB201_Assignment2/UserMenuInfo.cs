using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    ///  This is a class for displaying the user menu of the Arriba Eats application.
    /// </summary>
    internal class UserMenuInfo
    {
        private User user;
        public UserMenuInfo(User user)
        {
            this.user = user;
        }

        /// <summary>
        /// This method runs the user menu
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            /// Display the user information based on the user type
            CmdLineUI.DisplayMessage(user.GetUserInfo());           
            return true;   

        }
    }
}
