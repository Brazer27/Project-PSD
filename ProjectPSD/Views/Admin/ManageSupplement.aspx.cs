using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Admin
{
    public partial class ManageSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cek Admin atau bukan buat jaga jaga aja 
            HttpCookie cookie = Request.Cookies["user_cookie"];
            string temp = "";
            if (cookie == null)
            {
                var user = Session["user"] as MsUser;
                temp = user.UserID.ToString();
            }
            else
            {
                temp = cookie.Value;
            }

            MsUser userSession = AuthController.getUserById(temp);

            if (userSession.UserRole == "admin")
            {
                Response<List<MsSupplement>> Supplements = SupplementController.getSupplemets();
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.AddRange(new System.Data.DataColumn[5] {
                new System.Data.DataColumn("SupplementID"),
                new System.Data.DataColumn("SupplementName"),
                new System.Data.DataColumn("SupplementExpiryDate"),
                new System.Data.DataColumn("SupplementPrice"),
                new System.Data.DataColumn("SupplementTypeID")});

                if (Supplements.Success == true)
                {
                    int count = Supplements.Payload.Count;
                    for (int i = 0; i < count; i++)
                    {
                        string check = SupplementController.SupplementValidation(Supplements.Payload[i]);
                        if(check == "")
                        { 
                            dt.Rows.Add(Supplements.Payload[i].SupplementID, Supplements.Payload[i].SupplementName, Supplements.Payload[i].SupplementExpiryDate.Date.ToShortDateString(), Supplements.Payload[i].SupplementPrice, Supplements.Payload[i].SupplementTypeID);
                        }
                    }
                    GridManage.DataSource = dt;
                    GridManage.DataBind();
                }
                else
                {
                    errorlbl.Text = Supplements.Message;
                }
            }
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/InsertSupplement.aspx");
        }

        protected void GridManage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow Row = GridManage.Rows[e.RowIndex];
            int id = Convert.ToInt32(Row.Cells[0].Text);
            Response<MsSupplement> deleted = SupplementHandler.DeleteSupplement(id);
            if(deleted.Success == true)
            {
                Response.Redirect("~/Views/Admin/ManageSupplement.aspx");
            }
            else
            {
                errorlbl.Text = deleted.Message;
            }
        }

        protected void GridManage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // kalau on Row Editing tidak ada RowIndex
            GridViewRow Row = GridManage.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(Row.Cells[0].Text);
            Response.Redirect("~/Views/Admin/UpdateSupplement.aspx?SupplementID=" + id);
        }
    }
}