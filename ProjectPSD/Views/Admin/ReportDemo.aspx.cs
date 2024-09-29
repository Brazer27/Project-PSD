using ProjectPSD.Controller;
using ProjectPSD.Dataset;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class ReportDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            if (TransactionController.GetAllTransactionHeaders().Success)
            {
                DataSet1 data = getData(TransactionController.GetAllTransactionHeaders().Payload);
                report.SetDataSource(data);
            }
        }

        private DataSet1 getData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;
            var totalTable = data.SubTotal;
            var grandTotalTable = data.GrandTotal;

            var grandTotal = 0;

            foreach (TransactionHeader t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                headerTable.Rows.Add(hrow);
                var subTotal = 0;

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["ID"] = d.TransactionID;
                    drow["SupplementID"] = d.SupplementID;
                    drow["Quantity"] = d.Quantity;
                    var response = SupplementController.GetSupplementByID(d.SupplementID);
                    if (response.Success)
                    {
                        MsSupplement supplement = response.Payload;
                        drow["SupplementPrice"] = supplement.SupplementPrice;
                        subTotal += supplement.SupplementPrice * d.Quantity;
                    }
                    detailTable.Rows.Add(drow);
                }

                var totalRow = totalTable.NewRow();
                totalRow["ID"] = t.TransactionID;
                totalRow["Total"] = subTotal;
                totalTable.Rows.Add(totalRow);

                grandTotal += subTotal;
            }

            var grandTotalRow = grandTotalTable.NewRow();
            grandTotalRow["GrandTotal"] = grandTotal;
            grandTotalTable.Rows.Add(grandTotalRow);

            return data;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }
    }
}