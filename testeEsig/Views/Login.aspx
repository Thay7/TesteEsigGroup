<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="testeEsig.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Login</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <link href="~/Content/sweetalert2.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script src="~/Scripts/sweetalert2.all.min.js"></script>
    </head>
    <body>
        <div class="d-flex justify-content-center align-items-center min-vh-100">
            <div >
                <h2 class="mb-4">Login</h2>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div class="form-group">
                    <label for="txtUsername">Usuário:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Senha:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group mt-4">
                    <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="btn btn-primary w-100" />
                </div>
            </div>
        </div>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
    </body>
    </html>
</asp:Content>
