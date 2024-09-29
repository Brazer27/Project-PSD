<%@ Page Title="Transaction Report" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ProjectPSD.Views.Admin.Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    
    <h1>To a more visible page to see the report, click the button</h1>
    <asp:Button ID="move" CssClass="btn btn-outline-info" runat="server" Text="ReportDemo" OnClick="move_Click" />

    <!-- kalau tidak kelihatan karena menggunakan navbar dan footer, maka liat ke file ReportDemo.aspx -->

</asp:Content>
