<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntroductoryScreen.aspx.cs" Inherits="DB_WEBFORM_PROJ.IntroductoryScreen" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to CampusBites</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="logo">
                <img src="Images/ls.png" alt="CampusBites Logo" />
            </div>
            <div class="button-container">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="styled-button" OnClick="btnLogin_Click" />
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="styled-button" OnClick="btnSignUp_Click" />
            </div>
        </div>
    </form>
</body>
</html>

