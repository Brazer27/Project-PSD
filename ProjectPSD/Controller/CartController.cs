using ProjectPSD.Factory;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class CartController
    {
        public static Response<string> checkQuantity(int quantity)
        {
            if (quantity >= 1)
            {
                return new Response<string>()
                {
                    Success = true,
                    Message = "Quantity valid",
                    Payload = "Request Valid"
                };
            }
            else
            {
                return new Response<string>()
                {
                    Success = false,
                    Message = "Quantity not valid",
                    Payload = "Request not Valid"
                };
            }
        }

        public static Response<List<MsCart>> getAllCarts(int UserID)
        {
            return CartHandler.getAllCarts(UserID);
        }

        public static Response<MsCart> Create(int UserID, int SupplementID, int quantity)
        {
            return CartHandler.Create(UserID, SupplementID, quantity);
        }
        public static Response<List<MsCart>> clearCart(int UserID)
        {
            return CartHandler.clearCart(UserID);
        }
    }
}