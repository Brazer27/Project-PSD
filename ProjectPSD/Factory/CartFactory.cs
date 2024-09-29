using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class CartFactory
    {
        public static MsCart create (int UserID, int supplementID, int quantity)
        {
            return new MsCart()
            {
                UserID = UserID,
                SupplementID = supplementID,
                Quantity = quantity
            };
        }
    }
}