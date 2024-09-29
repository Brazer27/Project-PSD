using ProjectPSD.Controller;
using ProjectPSD.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Guest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_button_Click(object sender, EventArgs e)
        {
            string username = username_txt.Text;
            string email = email_txt.Text;
            string birthdayString = dob.Text;
            string gender = gender_dropdown.SelectedValue;
            string password = password_txt.Text;
            string confirmPassword = password_confirm_txt.Text;

            string response = AuthController.checkRegister(username, email, password, confirmPassword, birthdayString, gender);

            if (response == "")
            {
                response = AuthController.doRegister(username, email, password, birthdayString, gender);
                if(response == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    error_lbl.Text = response;
                }
            }
            else
            {
                error_lbl.Text = response;
            }
        }
    }
}