using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Factories
{
    public class CartFactory
    {
        public static Cart create_cart (int userID, int stationeryID, int quantity)
        {
            Cart cart = new Cart()
            {
                UserID = userID,
                StationeryID = stationeryID,
                Quantity = quantity
            };

            return cart;
        }
    }
}