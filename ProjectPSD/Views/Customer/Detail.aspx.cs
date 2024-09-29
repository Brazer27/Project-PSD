using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Customer
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ambil Transaction ID sama ambil transaction detial dari id 
            int TransactionID = Convert.ToInt32(Request["TransactionID"]);
            Response<List<ProjectPSD.Models.TransactionDetail>> details = TransactionController.GetTransactionDetailCustomer(TransactionID);

            // Cari Role
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

            // Kalau Role User ga nampilin UserID
            if (userSession.UserRole == "user")
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.AddRange(new System.Data.DataColumn[6] {
                new System.Data.DataColumn("SupplementName"),
                new System.Data.DataColumn("SupplementExpiryDate"),
                new System.Data.DataColumn("SupplementPrice"),
                new System.Data.DataColumn("SupplementTypeName"),
                new System.Data.DataColumn("Quantity"),
                new System.Data.DataColumn("TransactionDate")});

                if (details.Success == true)
                {
                    Response<TransactionHeader> header = TransactionController.GetTransactionHeaderByID(TransactionID);
                    int count = details.Payload.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Response<MsSupplement> supplements = SupplementController.getSupplementByID(details.Payload[i].SupplementID);
                        Response<MsSupplementType> typename = SupplementController.getSupplementType(supplements.Payload.SupplementTypeID);
                        dt.Rows.Add(supplements.Payload.SupplementName, supplements.Payload.SupplementExpiryDate.Date.ToShortDateString(), supplements.Payload.SupplementPrice, typename.Payload.SupplementTypeName, details.Payload[i].Quantity, header.Payload.TransactionDate.Date.ToShortDateString());
                    }
                    GridDetail.DataSource = dt;
                    GridDetail.DataBind();
                }
            }
            else
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.AddRange(new System.Data.DataColumn[7] {
                new System.Data.DataColumn("SupplementName"),
                new System.Data.DataColumn("SupplementExpiryDate"),
                new System.Data.DataColumn("SupplementPrice"),
                new System.Data.DataColumn("SupplementTypeName"),
                new System.Data.DataColumn("Quantity"),
                new System.Data.DataColumn("TransactionDate"),
                new System.Data.DataColumn("UserID")});

                if (details.Success == true)
                {
                    Response<TransactionHeader> header = TransactionController.GetTransactionHeaderByID(TransactionID);
                    int count = details.Payload.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Response<MsSupplement> supplements = SupplementController.getSupplementByID(details.Payload[i].SupplementID);
                        Response<MsSupplementType> typename = SupplementController.getSupplementType(supplements.Payload.SupplementTypeID);
                        dt.Rows.Add(supplements.Payload.SupplementName, supplements.Payload.SupplementExpiryDate.Date.ToShortDateString(), supplements.Payload.SupplementPrice, typename.Payload.SupplementTypeName, details.Payload[i].Quantity, header.Payload.TransactionDate.Date.ToShortDateString(), header.Payload.UserID);
                    }
                    GridAdmin.DataSource = dt;
                    GridAdmin.DataBind();
                }
            }
        }
    }
}