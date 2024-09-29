using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MsUser> users = AuthController.getAllCustomer();

                if (users != null && users.Count > 0)
                {
                    usersRepeater.DataSource = users;
                    usersRepeater.DataBind();
                    string count = users.Count.ToString();
                    count_lbl.Text = "Customer count:" + count;
                }
                else
                {
                    count_lbl.Text = "No user found";
                }
            }
        }
    }
}