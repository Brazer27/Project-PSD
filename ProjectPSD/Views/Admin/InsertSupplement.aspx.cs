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
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            string supplementname = nametb.Text;
            string isValidName = SupplementController.SupplementNameValidation(supplementname);

            string expirydatetext = expirydatetb.Text;
            string isValidDate = "";
            
            isValidDate = SupplementController.checkDateinString(expirydatetext);
            if(isValidDate == "")
            {
                DateTime expirydate = DateTime.Parse(expirydatetext);
                int price = Convert.ToInt32(pricetb.Text);
                string isValidPrice = SupplementController.PriceValidation(price);

                string typeIDString = typeIDtb.SelectedValue;
                int typeID = Convert.ToInt32(typeIDString);
                string isValidTypeID = SupplementController.TypeIDValidation(typeID);

                if (isValidName == "" && isValidDate == "" && isValidPrice == "" && isValidTypeID == "")
                {
                    Response<MsSupplement> newSupplement = SupplementHandler.CreateSupplement(supplementname, expirydate, price, typeID);
                    if (newSupplement.Success == true)
                    {
                        Response.Redirect("~/Views/Admin/ManageSupplement.aspx");
                    }
                    else
                    {
                        errorlbl.Text = "Failed to Create";
                    }
                }
                else
                {
                    if (isValidTypeID != "")
                    {
                        errorlbl.Text = isValidTypeID;
                    }

                    if (isValidPrice != "")
                    {
                        errorlbl.Text = isValidPrice;
                    }

                    if (isValidDate != "")
                    {
                        errorlbl.Text = isValidDate;
                    }

                    if (isValidName != "")
                    {
                        errorlbl.Text = isValidName;
                    }
                }
            }
            else
            {
                errorlbl.Text = isValidDate;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ManageSupplement.aspx");
        }
    }
}