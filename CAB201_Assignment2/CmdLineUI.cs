using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// Class for controlling the command line UI.
    /// </summary>
    internal class CmdLineUI
    {
        /// <summary>
        /// Displays a message on the command line.
        /// </summary>
        public static void DisplayMessage()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a message on the command line with the provided string.
        /// </summary>
        /// <param name="msg">message</param>
        public static void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Gets the user's choice 
        /// </summary>
        /// <returns></returns>
        public static int GetChoice()
        {
            string input = Console.ReadLine();
            int i = int.Parse(input);
            return i - 1; 
        }

        /// <summary>
        /// Gets an integer input from the user with a message prompt.
        /// </summary>
        /// <param name="msg">message</param>
        /// <returns></returns>
        public static int GetInt(string msg)
        {
            Console.WriteLine($"{msg}");
            string input = Console.ReadLine();
            int i = int.Parse(input);
            return i;
        }

        /// <summary>
        /// Gets an integer input from the user without a message prompt.
        /// </summary>
        /// <returns></returns>
        public static string GetString()
        {
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Gets a string input from the user with a message prompt.
        /// </summary>
        /// <param name="msg">message</param>
        /// <returns></returns>
        public static string GetString(string msg)
        {
            Console.WriteLine($"{msg}");
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Gets an option from the user based on the provided title and options.
        /// </summary>
        /// <param name="title">Take title</param>
        /// <param name="options">Take all of "options"</param>
        /// <returns></returns>
        public static int GetOption(string title, params object[] options)
        {

            if (options.Length <= 0)
            {
                return -1;
            }

            if (title != null)
            {
                CmdLineUI.DisplayMessage(title);
            }

            //Format the options with padding for alignment
            int digitsNeeded = (int)(1 + Math.Floor(Math.Log10(options.Length)));
            for (int i = 0; i < options.Length; i++)
            {
                CmdLineUI.DisplayMessage($"{(i + 1).ToString().PadLeft(digitsNeeded)}: {options[i]}");
            }

            int option = GetInt($"Please enter a choice between 1 and {options.Length}:");

            // need to subtract 1 to align because programers count from zero 
            return option - 1;
        }

        /// <summary>
        /// Displays the list of items in an order.
        /// </summary>
        /// <param name="order">current order</param>
        public static void DisplayListItem(Order order)
        {
            Dictionary<string, int> ListItem = order.GetListItem();

            foreach (var item in ListItem)
            {
                CmdLineUI.DisplayMessage($"{item.Value} x {item.Key}");
            }
            CmdLineUI.DisplayMessage();
        }

        /// <summary>
        /// This method displays a list of items with their corresponding string representation and prompts the user to select an option from the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"> list of items that is used to replace in for loop</param>
        /// <param name="itemToString">this is an item need to be display</param>
        /// <param name="prompt">The header</param>
        /// <returns></returns>
        public static int GetChoiceFromListOption<T>(List<T> items, Func<T, string> itemToString, string prompt)
        {
            int currentOption = 1;
            CmdLineUI.DisplayMessage(prompt);
            foreach (var item in items)
            {
                CmdLineUI.DisplayMessage($"{currentOption}: {itemToString(item)}");
                currentOption++;
            }
            CmdLineUI.DisplayMessage($"{currentOption}: Return to the previous menu");
            CmdLineUI.DisplayMessage($"Please enter a choice between 1 and {currentOption}:");
            int userOption = GetChoice(); 
            return userOption;
        }
    }
}
