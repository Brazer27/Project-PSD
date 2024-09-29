using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class DetailFactory
    {
        public static TransactionDetail create(int transactionID, int supplementID, int quantity)
        {
            return new TransactionDetail()
            {
                TransactionID = transactionID,
                SupplementID = supplementID,
                Quantity = quantity
            };
        }
    }
}