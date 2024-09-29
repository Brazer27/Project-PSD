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
    public class TransactionsHandler
    {
        public static Response<TransactionHeader> CreateHeader(int UserID, string Status)
        {

            TransactionHeader newHeader = HeaderFactory.create(UserID, Status);
            TransactionRepository.CreateHeader(newHeader);

            return new Response<TransactionHeader>()
            {
                Success = true,
                Message = "Header has been Created!",
                Payload = newHeader
            };
        }

        public static Response<TransactionDetail> CreateDetail(int TransactionID, int SupplementID, int quantity)
        {

            TransactionDetail newDetail = DetailFactory.create(TransactionID, SupplementID, quantity);
            TransactionRepository.CreateDetail(newDetail);

            return new Response<TransactionDetail>()
            {
                Success = true,
                Message = "Detail has been Created!",
                Payload = newDetail
            };
        }

        public static Response<List<TransactionHeader>> GetTransactionCustomer(int UserID)
        {
            List<TransactionHeader> transactionHeaders = TransactionRepository.GetTransactionHeadersCustomer(UserID);
            if (transactionHeaders.Count > 0)
            {
                return new Response<List<TransactionHeader>>()
                {
                    Success = true,
                    Message = "Get Transaction Headers Successfull",
                    Payload = transactionHeaders
                };
            }
            else
            {
                return new Response<List<TransactionHeader>>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }
        }

        public static Response<List<TransactionDetail>> GetTransactionDetailCustomer(int TransactionID)
        {
            List<TransactionDetail> transactionDetails = TransactionRepository.GetTransactionDetailsCustomer(TransactionID);
            if (transactionDetails.Count > 0)
            {
                return new Response<List<TransactionDetail>>()
                {
                    Success = true,
                    Message = "Get Transaction Details Successfull",
                    Payload = transactionDetails
                };
            }
            else
            {
                return new Response<List<TransactionDetail>>()
                {
                    Success = false,
                    Message = "Failed",
                    Payload = null
                };
            }
        }

        public static Response<TransactionHeader> GetTransactionHeaderByID(int TransactionID)
        {
            TransactionHeader header = TransactionRepository.getTransactionHeaderByID(TransactionID);
            if (header != null)
            {
                return new Response<TransactionHeader>()
                {
                    Success = true,
                    Message = "Header successfully found",
                    Payload = header
                };
            }
            else
            {
                return new Response<TransactionHeader>()
                {
                    Success = false,
                    Message = "not found",
                    Payload = null
                };
            }
        }

        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            List<TransactionHeader> headers = TransactionRepository.GetAllTransactionHeaders();

            if (headers != null)
            {
                return new Response<List<TransactionHeader>>()
                {
                    Success = true,
                    Message = "Successfully get all transaction headers",
                    Payload = headers
                };
            }
            else
            {
                return new Response<List<TransactionHeader>>()
                {
                    Success = false,
                    Message = "Unsuccessfull",
                    Payload = null
                };
            }
        }

        public static Response<TransactionHeader> changeStatus(int TransactionID)
        {
            TransactionHeader header = TransactionRepository.changeStatus(TransactionID);

            if (header != null)
            {
                return new Response<TransactionHeader>()
                {
                    Success = true,
                    Message = "Status successfully changed",
                    Payload = header
                };
            }
            else
            {
                return new Response<TransactionHeader>()
                {
                    Success = false,
                    Message = "not found",
                    Payload = null
                };
            }
        }
    }
}