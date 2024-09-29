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
    public class TransactionController
    {
        public static Response<TransactionHeader> CreateHeader(int UserID, string Status)
        {
            return TransactionsHandler.CreateHeader(UserID, Status);
        }

        public static Response<TransactionDetail> CreateDetail(int TransactionID, int SupplementID, int quantity)
        {
            return TransactionsHandler.CreateDetail(TransactionID, SupplementID, quantity);
        }

        public static Response<List<TransactionHeader>> GetTransactionCustomer(int UserID)
        {
            return TransactionsHandler.GetTransactionCustomer(UserID);
        }

        public static Response<List<TransactionDetail>> GetTransactionDetailCustomer(int TransactionID)
        {
            return TransactionsHandler.GetTransactionDetailCustomer(TransactionID);
        }

        public static Response<TransactionHeader> GetTransactionHeaderByID(int TransactionID)
        {
            return TransactionsHandler.GetTransactionHeaderByID(TransactionID);
        }

        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            return TransactionsHandler.GetAllTransactionHeaders();
        }

        public static Response<TransactionHeader> changeStatus(int TransactionID)
        {
            return TransactionsHandler.changeStatus(TransactionID);
        }
    }
}