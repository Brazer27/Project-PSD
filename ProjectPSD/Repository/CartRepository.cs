using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class CartRepository
    {
        private static ProjectDatabaseEntities3 db = Singleton.GetInstance();

        public static List<MsCart> getAllCarts(int UserID)
        {
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == UserID select c).ToList();
            return carts;
        }

        public static void createCart(MsCart cart)
        {
            db.MsCarts.Add(cart);
            db.SaveChanges();
        }

        public static List<MsCart> clearCart(int UserID)
        {
            List<MsCart> carts = (from c in db.MsCarts where c.UserID == UserID select c).ToList();

            foreach(MsCart cart in carts)
            {
                removeCart(cart);
            }
            db.SaveChanges();
            return carts;
        }

        public static void removeCart(MsCart cart)
        {
            db.MsCarts.Remove(cart);
            db.SaveChanges();
        }

        public static List<MsCart> removeCartBySupplementID(MsSupplement supplement)
        {
            List<MsCart> carts = (from c in db.MsCarts where c.SupplementID == supplement.SupplementID select c).ToList();

            foreach(MsCart cart in carts)
            {
                removeCart(cart);
            }
            db.SaveChanges();
            return carts;
        }
    }
}