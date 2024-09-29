using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class UserFactory
    {
        public static MsUser create(string UserName, string UserEmail, DateTime UserDOB, string UserGender, string UserRole, string UserPassword)
        {
            return new MsUser()
            {
                UserName = UserName,
                UserEmail = UserEmail,
                UserDOB = UserDOB,
                UserGender = UserGender,
                UserRole = UserRole,
                UserPassword = UserPassword
            };
        }
    }
}