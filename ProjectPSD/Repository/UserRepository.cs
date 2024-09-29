using ProjectPSD.Factory;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectPSD.Repository
{
    public class UserRepository
    {
        static ProjectDatabaseEntities3 db = Singleton.GetInstance();

        public static MsUser createUser(string name, string email, string gender, string role, DateTime dob, string password)
        {
            MsUser user = UserFactory.create(name, email, dob, gender, role, password);
            db.MsUsers.Add(user);
            db.SaveChanges();
            return user;
        }

        public static List<MsUser> getAllCustomer()
        {
           return (from user in db.MsUsers where user.UserRole.Equals("user") select user).ToList();
        }

        public static MsUser getUser(string name, string password)
        {
            return (from user in db.MsUsers
                    where user.UserName.Equals(name) && user.UserPassword.Equals(password)
                    select user).FirstOrDefault();
        }

        public static int getUserID(string UserID)
        {
            int temp = Convert.ToInt32(UserID);
            return (from user in db.MsUsers where user.UserID == temp select user.UserID).FirstOrDefault();
            
        }

        public static MsUser getUserById(string id)
        {
            return (from user in db.MsUsers
                    where user.UserID.ToString().Equals(id)
                    select user).FirstOrDefault();
        }

        public static string getPassword(string id)
        {
            string password = (from user in db.MsUsers
                               where user.UserID.ToString().Equals(id)
                               select user.UserPassword).FirstOrDefault();
            return password;
        }

        public static void editUser(string id, string name, string email, string gender, DateTime dob)
        {
            MsUser user = getUserById(id);

            user.UserName = name;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = dob;

            db.SaveChanges();
        }

        public static MsUser updatePassword(string id, string newPassword)
        {
            MsUser user = (from u in db.MsUsers
                           where u.UserID.ToString().Equals(id)
                           select u).FirstOrDefault();
            user.UserPassword = newPassword;
            db.SaveChanges();
            return user;
        }
    }
}