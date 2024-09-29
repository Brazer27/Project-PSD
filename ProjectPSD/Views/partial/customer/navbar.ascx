<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="navbar.ascx.cs" Inherits="ProjectPSD.Views.partial.header1" %>

<nav class="navbar navbar-expand-lg navbar-dark bg-dark p-3 sticky-top">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">GymMe</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
    
      <div class=" collapse navbar-collapse sticky-top" id="navbarNavDropdown">
        <ul class="navbar-nav ms-auto ">
          <li class="nav-item">
            <a class="nav-link mx-2 active" href="OrderSupplement.aspx">Order Supplement</a>
          </li>
          <li class="nav-item">
            <a class="nav-link mx-2 active" href="History.aspx">History</a>
          </li>
          <li class="nav-item">
            <a class="nav-link mx-2 active" href="../Customer/CustomerProfile.aspx">Profile</a>
          </li>
          <li>
            <asp:Button ID="logout"  class="btn btn-outline-danger" runat="server" Text="Logout" OnClick="logout_Click" />
          </li>
        </ul>
      </div>
    </div>
    </nav>

