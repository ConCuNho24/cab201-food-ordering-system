using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// Program class to run the Arriba Eats application.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Start the application
            WelcomeMenu menu = new WelcomeMenu();
            menu.Run();
        }  
    }
}
