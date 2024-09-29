<%@ Page Title="Insert Supplement" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="InsertSupplement.aspx.cs" Inherits="ProjectPSD.Views.Admin.InsertSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <section class="vh-100 w-100" style="">
  <div class="mask d-flex align-items-center h-100 gradient-custom-3">
    <div class="container h-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-md-6">
          <div class="card">
            <div class="card-body p-4">
              <h2 class="text-uppercase text-center mb-4">Add New Supplement</h2>
                <div class="mb-3">
                    <label class="form-label" for="nametb">Supplement Name</label>
                    <asp:TextBox ID="nametb" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="expirydatetb">Expiry Date</label>
                    <asp:TextBox ID="expirydatetb" class="form-control" TextMode="Date" runat="server"/>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="pricetb">Price</label>
                    <asp:TextBox ID="pricetb" class="form-control" TextMode="Number" Text="0" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-4">
                    <label for="typeIDtb">Type ID</label>
                    <asp:DropDownList ID="typeIDtb" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Supplement Type" Value ="0" />
                        <asp:ListItem Text="Vitamins" Value="1" />
                        <asp:ListItem Text="Minerals" Value="2" />
                        <asp:ListItem Text="Botanicals" Value="3" />
                        <asp:ListItem Text="Amino Acids" Value="4" />
                        <asp:ListItem Text="Live Microbials" Value="5" />
                    </asp:DropDownList>
                </div>

                <div class="d-grid gap-2">
                    
                    <asp:Button ID="BtnInsert" class="btn btn-success btn-lg" runat="server" Text="Insert" OnClick="BtnInsert_Click" />
                </div>

                <div class="mb-3 row justify-content-center">
                    <div class="col-auto">
                        <div class="text-danger mt-3">
                            <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnBack" class="btn btn-lg" runat="server" Text="Back" OnClick="btnBack_Click"/>
              </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>
