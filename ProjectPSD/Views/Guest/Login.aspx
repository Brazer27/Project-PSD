<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectPSD.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" /> 
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <title>Login Page</title>
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
                  <h2 class="text-uppercase text-center mb-4">Log into an account</h2>

                  <form runat="server">
                    <div class="mb-3">
                        <asp:TextBox ID="username_txt" class="form-control" runat="server"></asp:TextBox>
                      <label class="form-label" for="username_txt">Username</label>
                    </div>

                    <div class="mb-3">
                    <asp:TextBox ID="password_txt" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                      <label class="form-label" for="password_txt">Password</label>
                    </div>

                    <div class="mb-3 row justify-content-center">
                    <div class="col-auto">
                            <div class="form-check">
                                <input type="checkbox" id="remember_me_checkbox" class="form-check-input" runat="server" />
                                <label class="form-check-label" for="remember_me_checkbox">Remember Me</label>
                            </div>
                        </div>
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="login_button" class="btn btn-success btn-lg" runat="server" Text="Login" OnClick="login_button_Click" />
                    </div>

                    <div class="mb-3 row justify-content-center">
                        <div class="col-auto">
                            <div class="text-danger mt-3">
                                <asp:Label ID="error_lbl" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                    <p class="text-center text-muted mt-5 mb-0">Don't have an account? <a href="Register.aspx"
                        class="fw-bold text-body"><u>Register here</u></a></p>

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
