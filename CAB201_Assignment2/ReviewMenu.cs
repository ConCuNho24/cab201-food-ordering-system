using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class for displaying the review menu for a restaurant in the Arriba Eats application.
    /// </summary>
    internal class ReviewMenu
    {
        private Restaurant restaurant;
        private List<Rating> listRating;

        /// <summary>
        /// Constructor for the ReviewMenu class.
        /// </summary>
        /// <param name="restaurant"></param>
        public ReviewMenu(Restaurant restaurant)
        {
            this.restaurant = restaurant;
            listRating = restaurant.GetListRating();
        }

        /// <summary>
        /// This method runs the review menu, allowing the user to view all reviews left for the restaurant.
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (listRating.Count == 0) CmdLineUI.DisplayMessage("No reviews have been left for this restaurant.");
            else
            {
                ShowAllReviews();
            }
            return true;
        }

        /// <summary>
        /// This method displays all reviews left for the restaurant in reverse order (most recent first).
        /// </summary>
        private void ShowAllReviews()
        {
            foreach (var rating in restaurant.GetListRating().AsEnumerable().Reverse())
            {
                CmdLineUI.DisplayMessage($"Reviewer: {rating.CustomerName}");
                string starSymbol = rating.GetStarSymbol();
                CmdLineUI.DisplayMessage($"Rating: {starSymbol}");
                CmdLineUI.DisplayMessage($"Comment: {rating.Text}");
                CmdLineUI.DisplayMessage();
            }
        }

    }
}
