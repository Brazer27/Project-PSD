using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace ProjectPSD.Repository
{
    public class TransactionRepository
    {
        private static ProjectDatabaseEntities3 db = Singleton.GetInstance();

        public static void CreateHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public static void CreateDetail(TransactionDetail detail)
        {
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactionHeadersCustomer(int UserID)
        {
            List<TransactionHeader> headers = (from c in db.TransactionHeaders where c.UserID == UserID select c).ToList();
            return headers;
        }

        public static List<TransactionDetail> GetTransactionDetailsCustomer(int TransactionID)
        {
            List<TransactionDetail> details = (from c in db.TransactionDetails where c.TransactionID == TransactionID select c).ToList();
            return details;
        }

        public static TransactionHeader getTransactionHeaderByID(int TransactionID)
        {
            return db.TransactionHeaders.Find(TransactionID);
        }

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }
        public static List<TransactionDetail> DeleteTransactionDetailBySupplementID(MsSupplement supplement)
        {
            List<TransactionDetail> details = (from c in db.TransactionDetails where c.SupplementID == supplement.SupplementID select c).ToList();
            foreach(TransactionDetail detail in details)
            {
                db.TransactionDetails.Remove(detail);
            }
            db.SaveChanges();
            return details;
        }
        public static TransactionHeader changeStatus(int TransactionID)
        {

            TransactionHeader header = db.TransactionHeaders.Find(TransactionID);
            if (header.Status == "Unhandled")
            {
                header.Status = "Handled";
            }
            else
            {
                header.Status = "Unhandled";
            }
            db.SaveChanges();
            
            return header;

        }
    }
}