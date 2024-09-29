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
    public class SupplementController
    {
        public static Response<List<MsSupplement>> getSupplemets()
        {
            Response<List<MsSupplement>> response = SupplementHandler.GetAllMsSupplement();
            return response;
        }

        public static Response<MsSupplementType> getSupplementType(int key)
        {
            Response<MsSupplementType> response = SupplementHandler.GetSupplementType(key);
            return response;
        }

        public static Response<MsSupplement> getSupplementByID(int key)
        {
            Response<MsSupplement> response = SupplementHandler.GetSupplementByID(key);
            return response;
        }

        public static string SupplementValidation(MsSupplement sup)
        {
            string response = "";
            int? Price = sup.SupplementPrice;
            int? TypeID = sup.SupplementTypeID;

            if (sup.SupplementName == "" || sup.SupplementExpiryDate == DateTime.MinValue || !Price.HasValue || !TypeID.HasValue)
            {
                return response = "Empty Field";
            }

            if (!sup.SupplementName.Contains("Supplement"))
            {
                return response = "Name must contain Supplement";
            }

            if(sup.SupplementExpiryDate.Date <= DateTime.Today)
            {
                return response = "Expiry Date is not in the Future :(";
            }

            if(sup.SupplementPrice < 3000)
            {
                return response = "Price must be atleast 3000";
            }

            return response;
        }

        public static string ExpiryDateValidation(DateTime expiryDate)
        {
            string response = "";
            
            if (expiryDate.Date <=  DateTime.Today)
            {
                return response = "Expiry date is not in the future :(";
            }
            else
            {
                return response;
            }
        }

        public static string SupplementNameValidation(string name)
        {
            string response = "";

            if(name == "")
            {
                return response = "cannot be empty";
            }

            if (!name.Contains("Supplement"))
            {
                return response = "Supplement name has to have the word 'Supplement'";
            }

            return response;
        }

        public static string PriceValidation(int price)
        {
            string response = "";
            int? test = price;

            if (!test.HasValue)
            {
                return response = "Price cannot be empty";
            }

            if(price < 3000)
            {
                return response = "Price atleast 3000";
            }

            return response;
        }

        public static string TypeIDValidation(int ID)
        {
            string response = "";
            int? test = ID;

            if(!test.HasValue)
            {
                return response = "Type ID cannot be empty";
            }
            if (ID == 0)
            {
                return response = "Type ID must be filled";
            }
            return response;
        }

        public static string checkDateinString(string dateinString)
        {
            string response = "";
            DateTime expiryDate;
            if (string.IsNullOrEmpty(dateinString))
            {
                
                return response = "Date is empty";
            }

            if (DateTime.TryParse(dateinString, out expiryDate))
            {
                if (expiryDate.Date <= DateTime.Today)
                {
                    return response = "Date is not valid (not in the future)";
                }
            }
            else
            {
                return response = "failed to parse";
            }

            return response;
        }
        public static Response<MsSupplement> GetSupplementByID(int id)
        {
            return SupplementHandler.GetSupplementByID(id);
        }
    }
}