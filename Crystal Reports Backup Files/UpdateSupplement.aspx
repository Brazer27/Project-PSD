<%@ Page Title="Update Supplement" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="ProjectPSD.Views.Admin.UpdateSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<style>
    .full-height {
        height: 100vh;
    }
</style>

<div class="container full-height d-flex align-items-center justify-content-center">
    <div class="row w-100">
        <div class="col-md-8 offset-md-2">
            <div class="card mb-3">
                <div class="card-body">
                    <h6 class="mb-2 text-primary">Supplement Data</h6>
                    <div class="mb-3">
                        <label class="form-label" for="nametb">Supplement Name</label><br />
                        <asp:TextBox ID="nametb" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label" for="expirydatetb">Expiry Date</label><br />
                        <asp:TextBox ID="expirydatetb" CssClass="form-control" TextMode="Date" runat="server"/>
                    </div>

                    <div class="mb-3">
                        <label class="form-label" for="pricetb">Price</label><br />
                        <asp:TextBox ID="pricetb" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group mb-4">
                        <label for="typeIDtb">Type ID</label><br />
                        <asp:DropDownList ID="typeIDtb" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Supplement Type" Value ="0" />
                            <asp:ListItem Text="Vitamins" Value="1" />
                            <asp:ListItem Text="Minerals" Value="2" />
                            <asp:ListItem Text="Botanicals" Value="3" />
                            <asp:ListItem Text="Amino Acids" Value="4" />
                            <asp:ListItem Text="Live Microbials" Value="5" />
                        </asp:DropDownList>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="backBtn" CssClass="btn btn-outline-secondary" runat="server" Text="Back" OnClick="backBtn_Click"/>
                        <asp:Button ID="editBtn" CssClass="btn btn-outline-secondary" runat="server" Text="Edit" OnClick="editBtn_Click"/>
                        <asp:Button ID="cancelBtn" CssClass="btn btn-outline-danger" runat="server" Text="Cancel" Visible="false" OnClick="cancelBtn_Click"/>
                        <asp:Button ID="updateBtn" CssClass="btn btn-outline-primary" runat="server" Text="Update" Visible="false" OnClick="updateBtn_Click"/>
                    </div>
                    <div class="mb-3 row justify-content-center">
                        <div class="col-auto">
                            <div class="text-danger mt-3">
                                <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
