using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Repository
{
    public class SupplementRepository
    {
        private static ProjectDatabaseEntities3 db = Singleton.GetInstance();

        public static List<MsSupplement> GetMsSupplements()
        {
            return db.MsSupplements.ToList();
        }

        public static MsSupplementType GetMsSupplementType(int key)
        {
            MsSupplementType toFind = (from c in db.MsSupplementTypes where c.SupplementTypeID == key select c).ToList().FirstOrDefault();
            return toFind;
        }

        public static MsSupplement GetSupplementByID(int id)
        {
            return (from c in db.MsSupplements where c.SupplementID == id select c).FirstOrDefault();
        }

        public static MsSupplement CreateSupplement(MsSupplement supplement)
        {
            MsSupplement create = supplement;
            db.MsSupplements.Add(create);
            db.SaveChanges();
            return create;
        }

        public static MsSupplement UpdateSupplement(int SupplementID, string name, DateTime Expirydate, int price, int typeID)
        {
            MsSupplement supplement = GetSupplementByID(SupplementID);

            supplement.SupplementName = name;
            supplement.SupplementExpiryDate = Expirydate;
            supplement.SupplementPrice = price;
            supplement.SupplementTypeID = typeID;

            db.SaveChanges();

            return supplement;
        }

        public static MsSupplement DeleteSupplement(int SupplementID)
        {
            MsSupplement supplement = GetSupplementByID(SupplementID);

            // harus delete cart sama delete transaction dl yang ada supplementID yang sama
            CartRepository.removeCartBySupplementID(supplement);
            TransactionRepository.DeleteTransactionDetailBySupplementID(supplement);

            db.MsSupplements.Remove(supplement);
            db.SaveChanges();
            return supplement;
        }

        public static int getSupplementPrice(int supplementID)
        {
            return (from c in db.MsSupplements where c.SupplementID == supplementID select c.SupplementPrice).FirstOrDefault();
        }
    }
}