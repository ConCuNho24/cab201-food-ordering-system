using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2
{
    /// <summary>
    /// This is a class representing a location 
    /// </summary>
    internal class Location
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// Constructor for the Location class
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// This method calculates the Manhattan distance to another location.
        /// </summary>
        /// <param name="endLocation"></param>
        /// <returns></returns>
        public int DistanceTo(Location endLocation)
        {
            return Math.Abs(X - endLocation.X) + Math.Abs(Y - endLocation.Y);
        }

        /// <summary>
        /// Return the location in string type
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
