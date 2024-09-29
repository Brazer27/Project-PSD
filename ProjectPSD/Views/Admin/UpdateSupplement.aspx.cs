using ProjectPSD.Controller;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Modules;
using ProjectPSD.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Admin
{
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSupplement();
                SetFieldsEnabled(false);
                SetButtonsVisibility(true, false, false);
            }
        }

        private void LoadSupplement()
        {
            int id = Convert.ToInt32(Request["SupplementID"]);
            Response<MsSupplement> supplement = SupplementController.getSupplementByID(id);
            nametb.Text = supplement.Payload.SupplementName;
            expirydatetb.Text = supplement.Payload.SupplementExpiryDate.ToString("yyyy-MM-dd");
            pricetb.Text = supplement.Payload.SupplementPrice.ToString();
            typeIDtb.Text = supplement.Payload.SupplementTypeID.ToString();
        }

        private void SetFieldsEnabled(bool enabled)
        {
            nametb.Enabled = enabled;
            expirydatetb.Enabled = enabled;
            typeIDtb.Enabled = enabled;
            pricetb.Enabled = enabled;
        }

        private void SetButtonsVisibility(bool editVisible, bool cancelVisible, bool updateVisible)
        {
            backBtn.Visible = editVisible;
            editBtn.Visible = editVisible;
            cancelBtn.Visible = cancelVisible;
            updateBtn.Visible = updateVisible;
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            SetFieldsEnabled(true);
            SetButtonsVisibility(false, true, true);
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            LoadSupplement();
            SetFieldsEnabled(false);
            SetButtonsVisibility(true, false, false);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(Request["SupplementID"]);

            string name = nametb.Text;
            string expirydatetext = expirydatetb.Text;
            string isValidDate = "";

            isValidDate = SupplementController.checkDateinString(expirydatetext);

            if(isValidDate == "")
            {
                string isValidName = SupplementController.SupplementNameValidation(name);
                DateTime expirydate = DateTime.Parse(expirydatetext);
                
                int price = Convert.ToInt32(pricetb.Text);
                string isValidPrice = SupplementController.PriceValidation(price);

                string typeIDString = typeIDtb.SelectedValue;
                int typeID = Convert.ToInt32(typeIDString);
                string isValidTypeID = SupplementController.TypeIDValidation(typeID);

                if (isValidName == "" && isValidDate == "" && isValidPrice == "" && isValidTypeID == "")
                {
                    Response<MsSupplement> updateSupplement = SupplementHandler.UpdateSupplement(ID, name, expirydate, price, typeID);
                    if (updateSupplement.Success == true)
                    {
                        Response.Redirect("~/Views/Admin/UpdateSupplement.aspx?SupplementID=" + ID);
                    }
                    else
                    {
                        errorlbl.Text = updateSupplement.Message;
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

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ManageSupplement.aspx");
        }
    }
}