using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class Singleton
    {
        private static ProjectDatabaseEntities3 instance;

        public static ProjectDatabaseEntities3 GetInstance()
        {
            // Jika belum ada instance maka buatlah sebuah instance baru
            if (instance == null)
            {
                instance = new ProjectDatabaseEntities3();
            }

            // Jika sudah ada
            return instance;
        }
    }
}