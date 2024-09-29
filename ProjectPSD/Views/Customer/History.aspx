<%@ Page Title="History" Language="C#" MasterPageFile="~/Views/partial/BaseUser.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="ProjectPSD.Views.Customer.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="transactionlbl" runat="server" Text="Transaction"></asp:Label><br />
        <asp:GridView ID="GridHistory" runat="server" AutoGenerateColumns="False" OnRowEditing="GridHistory_RowEditing" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:CommandField ButtonType="Button" HeaderText="" EditText="Details" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
