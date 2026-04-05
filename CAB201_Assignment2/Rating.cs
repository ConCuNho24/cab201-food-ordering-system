using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for representing a rating given by a customer in the Arriba Eats application.
    /// </summary>
    internal class Rating
    {
        public string CustomerName { get; private set; }
        public int Star { get; private set; }
        public string Text { get; private set; }

        /// <summary>
        /// Constructor for the Rating class.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Star"></param>
        /// <param name="Text"></param>
        public Rating(string Name, int Star, string Text)
        {
            this.CustomerName = Name;   
            this.Star = Star;
            this.Text = Text;   
        }

        /// <summary>
        /// This method returns a string representation of the rating
        /// </summary>
        /// <returns></returns>
        public string GetStarSymbol()
        {
            string starSymbol = "";
            for (int i = 0; i < Star; i++)
            {
                starSymbol += "*";
            }
            return starSymbol;
        }

        
        
    }
}
