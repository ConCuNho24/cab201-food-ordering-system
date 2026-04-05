using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment2

{
    /// <summary>
    /// This is an enum for the status of an order in the Arriba Eats application.
    /// </summary>
    public enum OrderStatus
    {
        Ordered,
        Cooking,
        Cooked,
        BeingDelivered,
        Delivered
    }

    /// <summary>
    /// This is a class for representing an order in the Arriba Eats application.
    /// </summary>
    internal class Order
    {
        public int Number { get; private set; }

        private Customer customer;
        private Restaurant restaurant;
        private double TotalPrice;

        // This dictionary holds the items ordered by the customer, where the key is the item name and the value is the quantity ordered.
        private Dictionary<string, int> listItemsOrdered = new Dictionary<string, int>();

        // / This property holds the status of the order, which can be one of the values defined in the OrderStatus enum.
        public OrderStatus Status { get; private set; } = OrderStatus.Ordered; // is initialised to Ordered by default

        private Deliverer deliverer;
        public bool isAssigned { get; private set; } = false ;
        public bool isDelivererArrived { get; private set; } = false;    
        private Rating rating;

        /// <summary>
        /// Constructor for the Order class.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="customer"></param>
        /// <param name="restarant"></param>
        /// <param name="totalPrice"></param>
        /// <param name="listItems"></param>
        public Order(int number, Customer customer, Restaurant restarant, double totalPrice, Dictionary<string, int> listItems)
        {
            Number = number;
            this.customer = customer;
            this.restaurant = restarant;
            TotalPrice = totalPrice;
            listItemsOrdered = listItems;
        }

        /// <summary>
        /// This method updates the rating of the order.
        /// </summary>
        /// <param name="rating">order rating</param>
        public void UpdateRating(Rating rating)
        {
            this.rating = rating;
        }

        /// <summary>
        /// This method updates the status of the order.
        /// </summary>
        /// <param name="status"></param>
        public void UpdateStatus(OrderStatus status)
        {
            Status = status;   
        }

        /// <summary>
        /// This method returns a string representation of the order status.
        /// </summary>
        /// <returns></returns>
        public string GetStatusString()
        {
            if (Status == OrderStatus.BeingDelivered)
                return "Being Delivered";
            else
                return Status.ToString();
        }

        /// <summary>
        /// This method marks the order as having the deliverer arrived at the restaurant to pick up the order.
        /// </summary>
        public void MarkDelivererArrived()
        {
            isDelivererArrived = true;
        }

        /// <summary>
        /// This method returns the total price of the order.
        /// </summary>
        /// <returns></returns>
        public double GetTotalPrice()
        {
            return TotalPrice;
        }

        /// <summary>
        /// This method assigns a deliverer to the order, marking it as assigned.
        /// </summary>
        /// <param name="deliverer"></param>
        public void Assign(Deliverer deliverer)
        {
            isAssigned = true;
            this.deliverer = deliverer;
        }

        /// <summary>
        /// This method retrieves the name of the customer who placed the order.
        /// </summary>
        /// <returns></returns>
        public string GetCustomerName()
        {
            return customer.Name;
        }

        /// <summary>
        /// This method retrieves the name of the restaurant where the order was placed.
        /// </summary>
        /// <returns></returns>
        public string GetRestaurantName()
        {
            return restaurant.Name;
        }

        /// <summary>
        /// This method retrieves the name of the deliverer of this order
        /// </summary>
        /// <returns></returns>
        public string GetDelivererName()
        {
            return deliverer.Name;
        }

        /// <summary>
        /// This method retrieves the licence plate of the deliverer assigned to this order.
        /// </summary>
        /// <returns></returns>
        public string GetDelivererPlate()
        {
            return deliverer.LicencePlate;
        }

        /// <summary>
        /// This method retrieves the list of items ordered in the order, where the key is the item name and the value is the quantity ordered.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetListItem()
        {
            return new Dictionary<string, int>(listItemsOrdered);
        }

        /// <summary>
        /// This method retrieves the rating of the order, if it exists.
        /// </summary>
        /// <returns></returns>
        public Rating GetOrderRating()
        {
            if (rating == null) return null;
            else return rating;
        }

        /// <summary>
        /// This method retrieves the location of the restaurant where the order was placed.
        /// </summary>
        /// <returns></returns>
        public Location GetRestaurantLocation()
        {
            return restaurant.location;
        }

        /// <summary>
        /// This method retrieves the location of the customer who placed the order.
        /// </summary>
        /// <returns></returns>
        public Location GetCustomerLocation()
        {
            return customer.location;
        }
    }
}
