<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="DB_WEBFORM_PROJ.LoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - CampusBites</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style>
      h2 {
            color: orange;
            margin-bottom: 20px;
        }
    </style>

</head>
<body>
    <form runat="server">
        <div class="container">
            <h2>Login</h2>
            <div class="input-container">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="text-input" placeholder="Username"></asp:TextBox>
            </div>
            <div class="input-container">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="text-input" placeholder="Password"></asp:TextBox>
            </div>
            <div class="button-container">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="styled-button" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
