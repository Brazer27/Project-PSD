using Microsoft.SqlServer.Server;
using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Customer
{
    public partial class customer_profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserData();
                SetFieldsEnabled(false);
                SetButtonsVisibility(true, false, false);
            }
        }

        private void LoadUserData()
        {
            HttpCookie cookie = Request.Cookies["user_cookie"];
            string userId = "";
            if (cookie == null)
            {
                var user = Session["user"] as MsUser;
                if (user != null)
                {
                    userId = user.UserID.ToString();
                }
            }
            else
            {
                userId = cookie.Value;
            }

            MsUser userSession = AuthController.getUserById(userId);
            username.Text = userSession.UserName;
            email.Text = userSession.UserEmail;
            gender.SelectedValue = userSession.UserGender;
            dob.Text = userSession.UserDOB.ToString("yyyy-MM-dd");

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            SetFieldsEnabled(true);
            SetButtonsVisibility(false, true, true);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            LoadUserData();
            SetFieldsEnabled(false);
            SetButtonsVisibility(true, false, false);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string old_name = username.Text;
            string old_email = email.Text;
            string old_gender = gender.SelectedValue;
            string old_dob = dob.Text;


            string response = AuthController.checkUpdate(old_name, old_email, old_gender, old_dob);

            if (response == "")
            {
                HttpCookie cookie = Request.Cookies["user_cookie"];
                string userId = "";
                if (cookie == null)
                {
                    var user = Session["user"] as MsUser;
                    if (user != null)
                    {
                        userId = user.UserID.ToString();
                    }
                }
                else
                {
                    userId = cookie.Value;
                }

                AuthController.doUpdateUser(userId, old_name, old_email, old_gender, old_dob);
                Response.Redirect("CustomerProfile.aspx");

            }
            else
            {
                error_lbl_top.Text = response;
            }

        }

        private void SetFieldsEnabled(bool enabled)
        {
            username.Enabled = enabled;
            email.Enabled = enabled;
            gender.Enabled = enabled;
            dob.Enabled = enabled;
        }

        private void SetButtonsVisibility(bool editVisible, bool cancelVisible, bool updateVisible)
        {
            edit.Visible = editVisible;
            cancel.Visible = cancelVisible;
            update.Visible = updateVisible;
        }

        protected void password_reset_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user_cookie"];
            string userId = "";
            if (cookie == null)
            {
                var user = Session["user"] as MsUser;
                if (user != null)
                {
                    userId = user.UserID.ToString();
                }
            }
            else
            {
                userId = cookie.Value;
            }

            if (!string.IsNullOrEmpty(userId))
            {
                string oldPassword = old_password.Text;
                string newPassword = new_password.Text;

                string response = AuthController.checkPassword(userId, oldPassword, newPassword);

                if (string.IsNullOrEmpty(response))
                {
                    AuthController.doPasswordReset(userId, newPassword);
                    Response.Redirect("CustomerProfile.aspx");
                }
                else
                {
                    error_lbl.Text = response;
                }
            }
        }
    }
}