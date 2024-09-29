using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProjectPSD.Controller
{
    public class AuthController
    {
        public static MsUser getUserById(string id)
        {
            MsUser user = AuthHandler.getUserById(id);
            return user;
        }

        public static void doUpdateUser(string id, string name, string email, string gender, string dob)
        {
            AuthHandler.doUpdateUser(id, name, email, gender, dob);
        }

        public static void doPasswordReset(string id, string newPassword)
        {
            AuthHandler.doPasswordReset (id, newPassword);
        }

        public static MsUser doLogin(string name, string password)
        {
            return AuthHandler.doLogin(name, password);
        }

        public static string doRegister(string name, string email, string password, string birthdayString, string gender)
        {
            return AuthHandler.doRegister(name, email, password, birthdayString, gender);
        }

        public static string checkRegister(string name, string email, string password, string confirmPassword, string birthdayString, string gender)
        {
            string response = "";


            if (email == "" || password == "" || confirmPassword == "" || name == "" || string.IsNullOrEmpty(birthdayString) || gender == "")
            {
                response = "All fields must be filled!";
            }
            else if (password != confirmPassword)
            {
                response = "Password and Confirm Password must be the same!";
            }
            else if (password.Length < 8 || password.Length > 15)
            {
                response = "Password must be between 8 and 15 characters!";
            }
            else
            {
                // no validation for email because the textmode for email is already for email
            }

            return response;
        }

        public static string checkLogin(string email, string password)
        {
            string response = "";

            if (email == "" || password == "")
            {
                response = "All fields must be filled!";
            }

            return response;
        }

        public static string checkUpdate(string name, string email, string gender, string birthdayString)
        {
            string response = "";

            if (email == "" ||  name == "" || string.IsNullOrEmpty(birthdayString) || gender == "")
            {
                response = "All fields must be filled!";
            }

            return response;

        }

        public static string checkPassword(string id, string old_password, string new_password)
        {
            string response = "";
            string password = AuthHandler.getPassword(id);

            if(old_password == "" || new_password == "")
            {
                response = "All fields must be filled!";
                return response;
            }
            else if (old_password == password) {
                if (new_password.Length < 8 || new_password.Length > 15)
                {
                    response = "Password must be between 8 and 15 characters!";
                    return response;
                }
                return response;
            } else
            {
                response = "Old password is incorrect!";
                return response;
            }
        }

        public static string getPassword(string id)
        {
            return AuthHandler.getPassword(id);

        }

        public static int getUserID(string id)
        {
            return AuthHandler.getUserID(id);
        }

        public static List<MsUser> getAllCustomer()
        {
            return AuthHandler.getAllCustomer();
        }
    }
}