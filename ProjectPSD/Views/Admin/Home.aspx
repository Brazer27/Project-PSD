<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectPSD.Views.Admin.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container full-height d-flex align-items-center justify-content-center">
        <div class="row w-100">
            <div class="col-md-12">
                <h5 class="mb-4 text-primary  align-items-center">Customer Information List</h5>
                <asp:Label ID="count_lbl" class="mb-4 text-secondary align-items-center" runat="server" Text=""></asp:Label>
                <div class="row">
                    <asp:Repeater ID="usersRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                                <div class="card">
                                    <div class="card-body">
                                        <h6 class="card-title"><%# Eval("UserName") %></h6>
                                        <p class="card-text">Email: <%# Eval("UserEmail") %></p>
                                        <p class="card-text">Gender: <%# Eval("UserGender") %></p>
                                        <p class="card-text">Date of Birth: <%# Eval("UserDOB", "{0:yyyy-MM-dd}") %></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
