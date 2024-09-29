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
    public class SupplementHandler
    {
        public static Response<List<MsSupplement>> GetAllMsSupplement()
        {
            List<MsSupplement> Supplements = SupplementRepository.GetMsSupplements();

            if(Supplements.Count == 0)
            {
                return new Response<List<MsSupplement>>()
                {
                    Success = false,
                    Message = "Supplements Table is Empty",
                    Payload = null
                };
            }
            else
            {
                return new Response<List<MsSupplement>>()
                {
                    Success = true,
                    Message = "Supplements Table Accessed!",
                    Payload = Supplements
                };
            }
        }
        public static Response<MsSupplementType> GetSupplementType(int key)
        {
            MsSupplementType SupplementType = SupplementRepository.GetMsSupplementType(key);
            
            if(SupplementType == null)
            {
                return new Response<MsSupplementType>()
                {
                    Success = false,
                    Message = "Supplement Type Not Found!",
                    Payload = null
                };
            }
            else
            {
                return new Response<MsSupplementType>()
                {
                    Success = true,
                    Message = "Supplement Type Found!",
                    Payload = SupplementType
                };
            }
        }

        public static Response<MsSupplement> GetSupplementByID(int id)
        {
            MsSupplement Supplement = SupplementRepository.GetSupplementByID(id);

            if(Supplement == null)
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Cannot find Supplement!",
                    Payload = null
                };
            }
            else
            {
                return new Response<MsSupplement>()
                {
                    Success = true,
                    Message = "Supplement Found",
                    Payload = Supplement
                };
            }
        }

        public static Response<MsSupplement> CreateSupplement(string name, DateTime expirydate, int price, int typeID)
        {
            MsSupplement supplement = MsSupplementFactory.create(name, expirydate, price, typeID);
            SupplementRepository.CreateSupplement(supplement);

            return new Response<MsSupplement>()
            {
                Success = true,
                Message = "Created Successfully",
                Payload = supplement
            };
        }

        public static Response<MsSupplement> UpdateSupplement(int ID, string name, DateTime expirydate, int price, int typeID)
        {
            MsSupplement supplement = SupplementRepository.GetSupplementByID(ID);
            SupplementRepository.UpdateSupplement(ID, name, expirydate, price, typeID);

            if(supplement != null)
            {
                return new Response<MsSupplement>()
                {
                    Success = true,
                    Message = "Successfully Updated",
                    Payload = supplement
                };
            }
            else
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Cannot find to Be Updated",
                    Payload = null
                };
            }
        }

        public static Response<MsSupplement> DeleteSupplement(int ID)
        {
            MsSupplement supplement = SupplementRepository.DeleteSupplement(ID);

            if(supplement != null)
            {
                return new Response<MsSupplement>()
                {
                    Success = true,
                    Message = "Successfully Deleted",
                    Payload = supplement
                };
            } 
            else
            {
                return new Response<MsSupplement>()
                {
                    Success = false,
                    Message = "Unsuccessfull delete",
                    Payload = null
                };
            }
        }

        public static Response<int> GetSupplementPrice(int supplementID)
        {
            int price = SupplementRepository.getSupplementPrice(supplementID);

            if(price == 0)
            {
                return new Response<int>()
                {
                    Success = false,
                    Message = "Price Not Found",
                    Payload = 0
                };
            }
            else
            {
                return new Response<int>()
                {
                    Success = true,
                    Message = "Price Found",
                    Payload = price
                };
            }
        }
    }
}