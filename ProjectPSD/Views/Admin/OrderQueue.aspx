<%@ Page Title="Order Queue" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="ProjectPSD.Views.Admin.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container mt-5">
            <h5 class="mb-4 text-primary  align-items-center">Order Queue List</h5>
            <asp:Label ID="count_lbl" class="mb-4 text-secondary align-items-center" runat="server" Text=""></asp:Label>
            <table class="table table-bordered table-responsive">
                <thead>
                    <tr>
                        <th scope="col">Transaction ID</th>
                        <th scope="col">User ID</th>
                        <th scope="col">Date</th>
                        <th scope="col">Status</th>
                        <th scope="col">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="headerRepeater" runat="server" OnItemDataBound="headerRepeater_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("TransactionID") %></td>
                                <td><%# Eval("UserID") %></td>
                                <td><%# Eval("TransactionDate", "{0:yyyy-MM-dd}") %></td>
                                <td><%# Eval("Status") %></td>
                                <td>
                                    <asp:Button ID="status_change" runat="server" Text="" CssClass="btn" CommandArgument='<%# Eval("TransactionID") %>' CommandName="ChangeStatus" OnCommand="changeBtn_Command" />                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
    </div>



</asp:Content>
