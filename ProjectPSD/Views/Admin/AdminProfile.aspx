<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Views/partial/BaseAdmin.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="ProjectPSD.Views.Admin.AdminProfile" %>
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
                    <h6 class="mb-2 text-primary">Personal Information</h6>
                    <div class="form-group mb-3">
                        <label for="username">Username</label>
                        <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label for="email">Email</label>
                        <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label for="gender">Gender</label>
                        <asp:DropDownList ID="gender" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Gender" Value="" />
                            <asp:ListItem Text="Female" Value="female" />
                            <asp:ListItem Text="Male" Value="male" />
                            <asp:ListItem Text="Other" Value="other" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group mb-3">
                        <label for="dob">Date of Birth</label>
                        <asp:TextBox ID="dob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="edit" CssClass="btn btn-outline-secondary" runat="server" Text="Edit" OnClick="edit_Click" />
                        <asp:Button ID="cancel" CssClass="btn btn-outline-danger" runat="server" Text="Cancel" Visible="false" OnClick="cancel_Click" />
                        <asp:Button ID="update" CssClass="btn btn-outline-primary" runat="server" Text="Update" Visible="false" OnClick="update_Click" />
                    </div>
                    <div class="mb-3 row justify-content-center">
                        <div class="col-auto">
                            <div class="text-danger mt-3">
                                <asp:Label ID="error_lbl_top" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <h6 class="mb-2 text-primary">Reset Password</h6>
                    <div class="form-group mb-3">
                        <label for="old_password">Old Password</label>
                        <asp:TextBox ID="old_password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter old password"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label for="new_password">New Password</label>
                        <asp:TextBox ID="new_password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter new password"></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="password_reset" runat="server" CssClass="btn btn-outline-danger" Text="Reset" OnClick="password_reset_Click"/>
                    </div>
                    <div class="mb-3 row justify-content-center">
                        <div class="col-auto">
                            <div class="text-danger mt-3">
                                <asp:Label ID="error_lbl" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
