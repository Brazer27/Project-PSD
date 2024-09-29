<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDemo.aspx.cs" Inherits="ProjectPSD.Views.ReportDemo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Demo</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Button to go back</h1>
        <asp:Button CssClass="btn btn-outline-info" ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />

        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        </div>

    </form>
</body>
</html>
