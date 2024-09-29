<%@ Page Title="Detail" Language="C#" MasterPageFile="~/Views/partial/BaseUser.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ProjectPSD.Views.Customer.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="gridlbl" runat="server" Text="Transaction Detail"></asp:Label><br />
        <asp:GridView ID="GridDetail" runat="server" AutoGenerateColumns="False" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="TransactionDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Supplement Type" SortExpression="SupplementTypeName" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridAdmin" runat="server" AutoGenerateColumns="False" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="TransactionDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Supplement Type" SortExpression="SupplementTypeName" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
