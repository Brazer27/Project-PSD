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
    public partial class OrderQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Response<List<TransactionHeader>> headers = TransactionController.GetAllTransactionHeaders();
                if (headers.Success == true)
                {
                    headerRepeater.DataSource = headers.Payload;
                    headerRepeater.DataBind();

                    count_lbl.Text = "Transaction count:" + headers.Payload.Count.ToString();

                }
                else
                {
                    count_lbl.Text = "No transaction";
                }
            }
        }

        protected void headerRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var transaction = (TransactionHeader)e.Item.DataItem;
                var actionButton = (Button)e.Item.FindControl("status_change");

                if (transaction.Status == "Unhandled")
                {
                    actionButton.Text = "Handle";
                    actionButton.CssClass = "btn btn-outline-success";
                }
                else
                {
                    actionButton.Text = "Unhandle";
                    actionButton.CssClass = "btn btn-outline-danger";
                }
            }
        }

        protected void changeBtn_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ChangeStatus")
            {
                int transactionID = Convert.ToInt32(e.CommandArgument);

                Response<TransactionHeader> headers = TransactionController.changeStatus(transactionID);

                if (headers.Success == true)
                {
                    Response.Redirect("OrderQueue.aspx");
                }
            }
        }
    }
}