<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectPSD.Views.Guest.WebForm1" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" /> 
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <title>Register Page</title>
</head>
<body>
    <section class="vh-100 bg-image"
      style="background-image: url('https://mdbcdn.b-cdn.net/img/Photos/new-templates/search-box/img4.webp');">
      <div class="mask d-flex align-items-center h-100 gradient-custom-3">
        <div class="container h-100">
          <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-md-6">
              <div class="card">
                <div class="card-body p-4">
                  <h2 class="text-uppercase text-center mb-4">Create an account</h2>

                  <form runat="server">
                    <div class="mb-3">
                        <asp:TextBox ID="username_txt" class="form-control" runat="server"></asp:TextBox>
                      <label class="form-label" for="username_txt">Username</label>
                    </div>

                    <div class="mb-3">
                       <asp:TextBox ID="email_txt" class="form-control" TextMode="Email" runat="server"></asp:TextBox>
                      <label class="form-label" for="email_txt">Email</label>
                    </div>

                    <div class="mb-3">
                        <asp:DropDownList class="form-select" ID="gender_dropdown" runat="server">
                            <asp:ListItem Text="Select Gender" Value="" />
                            <asp:ListItem Text="Female" Value="female" />
                            <asp:ListItem Text="Male" Value="male" />
                            <asp:ListItem Text="Other" Value="other" />
                        </asp:DropDownList>
                      <label class="form-label" for="gender_dropdown">Gender</label>
                    </div>

                    <div class="mb-3">
                      <asp:TextBox ID="dob" class="form-control" TextMode="Date" runat="server" />
                      <label class="form-label" for="dob">Date of Birth</label>
                    </div>

                    <div class="mb-3">
                    <asp:TextBox ID="password_txt" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                      <label class="form-label" for="password_txt">Password</label>
                    </div>

                    <div class="mb-3">
                    <asp:TextBox ID="password_confirm_txt" class="form-control" TextMode="Password"  runat="server"></asp:TextBox>
                      <label class="form-label" for="password_confirm_txt">Confirm Password</label>
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="register_button" class="btn btn-success btn-lg" runat="server" Text="Register" OnClick="register_button_Click" />
                    </div>

                    <div class="mb-3 row justify-content-center">
                        <div class="col-auto">
                            <div class="text-danger mt-3">
                                <asp:Label ID="error_lbl" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                    <p class="text-center text-muted mt-5 mb-0">Have already an account? <a href="Login.aspx"
                        class="fw-bold text-body"><u>Login here</u></a></p>

                  </form>

                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
</body>
</html>

