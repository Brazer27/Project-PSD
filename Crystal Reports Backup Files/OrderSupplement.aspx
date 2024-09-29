<%@ Page Title="Order Supplement" Language="C#" MasterPageFile="~/Views/partial/BaseUser.Master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="ProjectPSD.Views.Customer.OrderSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="orderlbl" runat="server" Text="Order Supplement"></asp:Label>
        <asp:GridView ID="GridOrderSupplement" runat="server" AutoGenerateColumns="False" OnRowEditing ="GridOrderSupplement_RowEditing" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Type Name" SortExpression="SupplementTypeName" />
                <asp:TemplateField HeaderText="Quantity">
                    <itemTemplate>
                        <asp:TextBox ID="tbQuantity" type="number" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    </itemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" HeaderText="" ShowEditButton="True" EditText="Order" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="cartlbl" runat="server" Text="" ></asp:Label>
        <asp:GridView ID="GridCart" runat="server" AutoGenerateColumns="False" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Type Name" SortExpression="SupplementTypeName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>

        </asp:GridView><br />
        <asp:Button ID="BtnClear" runat="server" Text="Clear Cart" onclick="BtnClear_Click"/>
        <asp:Button ID="BtnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" />
    </div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</asp:Content>
