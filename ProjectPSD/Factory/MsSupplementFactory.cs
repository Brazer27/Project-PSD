using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class MsSupplementFactory
    {
        public static MsSupplement create(string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeID)
        {
            return new MsSupplement()
            {
                SupplementName = supplementName,
                SupplementExpiryDate = supplementExpiryDate,
                SupplementPrice = supplementPrice,
                SupplementTypeID = supplementTypeID
            };
        }
    }
}