using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            string username = username_txt.Text;
            string password = password_txt.Text;
            bool rememberMe = remember_me_checkbox.Checked;

            string response = AuthController.checkLogin(username, password);

            if (response == "")
            {
                MsUser user = AuthController.doLogin(username, password);
                

                if(user == null)
                {
                    error_lbl.Text = "Login failed!";
                }
                else
                {
                    Session["user"] = user;

                    if (rememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = user.UserID.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }

                    if(user.UserRole == "admin")
                    {
                        Response.Redirect("../Admin/Home.aspx");
                    }
                    else if(user.UserRole == "user")
                    {
                        Response.Redirect("../Customer/OrderSupplement.aspx");
                    }

                }
            }
            else
            {
                error_lbl.Text = response;
            }
        }
    }
}
