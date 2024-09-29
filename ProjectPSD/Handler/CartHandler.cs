using ProjectPSD.Factory;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class CartHandler
    {
        public static Response<List<MsCart>> getAllCarts(int UserID)
        {
            List<MsCart> carts = CartRepository.getAllCarts(UserID);

            if(carts.Count > 0)
            {
                return new Response<List<MsCart>>()
                {
                    Success = true,
                    Message = "Successfully to get all carts",
                    Payload = carts
                };
            }
            else
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Failed to get all carts",
                    Payload = null
                };
            }
        }

        public static Response<MsCart> Create(int UserID, int SupplementID, int quantity)
        {

            MsCart newCart = CartFactory.create(UserID, SupplementID, quantity);
            CartRepository.createCart(newCart);

            return new Response<MsCart>()
            {
                Success = true,
                Message = "Cart has been Created!",
                Payload = newCart
            };
        }
        public static Response<List<MsCart>> clearCart(int UserID)
        {
            List<MsCart> deletedCart = CartRepository.clearCart(UserID);

            if (deletedCart.Count == 0)
            {
                return new Response<List<MsCart>>()
                {
                    Success = false,
                    Message = "Failed to Clear",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<MsCart>>()
                {
                    Success = true,
                    Message = "Cart Successfully Cleared!",
                    Payload = deletedCart
                };
            }
        }
    }
}