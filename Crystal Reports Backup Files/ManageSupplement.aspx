<%@ Page Title="Manage Supplement" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="ProjectPSD.Views.Admin.ManageSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="managelbl" runat="server" Text="Supplements"></asp:Label>
        <asp:GridView ID="GridManage" runat="server" AutoGenerateColumns="False" CellSpacing="2" CellPadding="5" OnRowEditing="GridManage_RowEditing" OnRowDeleting="GridManage_RowDeleting">
            <RowStyle HorizontalAlign="Center"></RowStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <Columns >
                <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
                <asp:CommandField ButtonType="Button" EditText="Update" ShowEditButton="True" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView><br />
        <div style="align-content:center; text-align:center;">
            <asp:Button ID="BtnInsert" CssClass="align-content-center" runat="server" Text="Insert" OnClick="BtnInsert_Click"/>
        </div>
    </div>
</asp:Content>
