using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class SupplementTypeFactory
    {
        public static MsSupplementType create(string SupplementTypeName)
        {
            return new MsSupplementType()
            {
                SupplementTypeName = SupplementTypeName,
            };
        }
    }
}