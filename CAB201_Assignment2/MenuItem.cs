using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class representing a menu item in the Arriba Eats application.
    /// </summary>
    internal class MenuItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        /// <summary>
        /// Constructor for the MenuItem class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }   
    }
}
