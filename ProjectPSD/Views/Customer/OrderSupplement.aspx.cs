using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Customer
{
    public partial class OrderSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // buat Supplement

                Response<List<MsSupplement>> response = SupplementController.getSupplemets();
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.AddRange(new System.Data.DataColumn[6] {
                new System.Data.DataColumn("SupplementID"),
                new System.Data.DataColumn("SupplementName"),
                new System.Data.DataColumn("SupplementExpiryDate"),
                new System.Data.DataColumn("SupplementPrice"),
                new System.Data.DataColumn("SupplementTypeName"),
                new System.Data.DataColumn("Quantity")});

                if (response.Success == true)
                {
                    int count = response.Payload.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Response<MsSupplementType> typename = SupplementController.getSupplementType(response.Payload[i].SupplementTypeID);
                        dt.Rows.Add(response.Payload[i].SupplementID, response.Payload[i].SupplementName, response.Payload[i].SupplementExpiryDate.Date.ToShortDateString(), response.Payload[i].SupplementPrice, typename.Payload.SupplementTypeName, "");
                    }
                    GridOrderSupplement.DataSource = dt;
                    GridOrderSupplement.DataBind();
                }
                else
                {
                    errorlbl.Text = response.Message;
                }

                // buat Cart

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

                int UserID = AuthController.getUserID(temp);

                Response<List<MsCart>> cartResponse = CartController.getAllCarts(UserID);
                System.Data.DataTable dtCart = new System.Data.DataTable();
                dtCart.Columns.AddRange(new System.Data.DataColumn[6] {
                new System.Data.DataColumn("SupplementID"),
                new System.Data.DataColumn("SupplementName"),
                new System.Data.DataColumn("SupplementExpiryDate"),
                new System.Data.DataColumn("SupplementPrice"),
                new System.Data.DataColumn("SupplementTypeName"),
                new System.Data.DataColumn("Quantity")});
                if (cartResponse.Success == true)
                {
                    cartlbl.Text = "Cart";
                    int countCart = cartResponse.Payload.Count;
                    for(int i = 0; i < countCart; i++)
                    {
                        Response<MsSupplement> supplements = SupplementController.getSupplementByID(cartResponse.Payload[i].SupplementID);
                        Response<MsSupplementType> typename = SupplementController.getSupplementType(supplements.Payload.SupplementTypeID);
                        dtCart.Rows.Add(supplements.Payload.SupplementID, supplements.Payload.SupplementName, supplements.Payload.SupplementExpiryDate.Date.ToShortDateString(), supplements.Payload.SupplementPrice, typename.Payload.SupplementTypeName, cartResponse.Payload[i].Quantity);
                    }
                    GridCart.DataSource = dtCart;
                    GridCart.DataBind();
                }
                else
                {
                    BtnClear.Style.Add("display", "none");
                    BtnCheckout.Style.Add("display", "none");
                }
            }
        }

        protected void GridOrderSupplement_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow Row = GridOrderSupplement.Rows[e.NewEditIndex];

            int SupplementID = Convert.ToInt32(Row.Cells[0].Text);
            TextBox tbQuantity = (TextBox)Row.FindControl("tbQuantity");
            int quantity = Convert.ToInt32(tbQuantity.Text);
            
            Response<string> response = CartController.checkQuantity(quantity);
            
            if (response.Success == true)
            {
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

                int UserID = AuthController.getUserID(temp);

                Response<MsCart> cart = CartController.Create(UserID, SupplementID, quantity);

                if(cart.Success == true)
                {
                    Response.Redirect("~/Views/Customer/OrderSupplement.aspx");
                }
                else
                {
                    errorlbl.Text = cart.Message;
                }
            }
            else
            {
                errorlbl.Text = response.Message;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            
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

            int UserID = AuthController.getUserID(temp);
            Response<List<MsCart>> clear = CartController.clearCart(UserID);

            if(clear.Success == true)
            {
                Response.Redirect("~/Views/Customer/OrderSupplement.aspx");
            }
            else
            {
                errorlbl.Text = clear.Message;
            }
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
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

            int UserID = AuthController.getUserID(temp);

            Response<List<MsCart>> cartResponse = CartController.getAllCarts(UserID);

            Response<TransactionHeader> header = TransactionController.CreateHeader(UserID, "Unhandled");
            int transactionID = header.Payload.TransactionID;

            if (header.Success == true)
            {
                int count = cartResponse.Payload.Count;

                for (int i = 0; i < count; i++)
                {
                    Response<TransactionDetail> detail = TransactionController.CreateDetail(transactionID, cartResponse.Payload[i].SupplementID, cartResponse.Payload[i].Quantity);
                    if (detail.Success != true)
                    {
                        errorlbl.Text = detail.Message;
                    }
                }
                
                Response<List<MsCart>> clear = CartController.clearCart(UserID);

                if (clear.Success == true)
                {
                    Response.Redirect("~/Views/Customer/OrderSupplement.aspx");
                }
                else
                {
                    errorlbl.Text = clear.Message;
                }
            }
        }
    }
}