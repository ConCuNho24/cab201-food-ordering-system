using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    internal class PlacingOrderMenu
    {
        public static double Display(MenuItem item)
        {
            Console.WriteLine("Please enter quantity (0 to cancel):");

            int quantity = int.Parse(Console.ReadLine());


            if (quantity == 0) Console.WriteLine("GO BACK");
            else
            {
                Console.WriteLine($"Added {quantity} x {item.Name} to order.");
            }

            return quantity * item.Price;
        }
    }
}
