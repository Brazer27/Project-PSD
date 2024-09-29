using ProjectPSD.Dataset;
using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            if(TransactionsHandler.GetAllTransactionHeaders().Success)
            {
                DataSet1 data = getData(TransactionsHandler.GetAllTransactionHeaders().Payload);
                report.SetDataSource(data);
            }

        }

        private DataSet1 getData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;
            //var totalTable = data.subTotal;

            foreach(TransactionHeader t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                headerTable.Rows.Add(hrow);

                //var total = 0;

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["ID"] = d.TransactionID;
                    drow["SupplementID"] = d.SupplementID;
                    drow["Quantity"] = d.Quantity;
                    var response = SupplementHandler.GetSupplementByID(d.SupplementID);
                    if (response.Success)
                    {
                        MsSupplement supplement = response.Payload;
                        drow["SupplementPrice"] = supplement.SupplementPrice;
                        //total += total + (supplement.SupplementPrice * d.Quantity);
                    }
                    detailTable.Rows.Add(drow);
                }

                //var trow = totalTable.NewRow();
                //trow["subTotal"] = total;
                //totalTable.Rows.Add(trow);
            }

            return data;
        }
    }
}