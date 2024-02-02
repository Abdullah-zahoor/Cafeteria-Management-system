<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoyaltyPage.aspx.cs" Inherits="DB_WEBFORM_PROJ.LoyaltyPage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loyalty Points</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            color: #333;
        }
        .container {
            width: 80%;
            margin: 40px auto;
            padding: 20px;
            text-align: center;
            background-color: white;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        h2 {
            color: #4CAF50;
            margin-bottom: 30px;
        }
        .loyalty-details {
            margin-bottom: 25px;
            font-size: 20px;
            color: #555;
        }
        .styled-button {
            background-color: #4CAF50;
            color: white;
            padding: 12px 25px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 18px;
            transition: background-color 0.3s ease;
        }
        .styled-button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Your Loyalty Points</h2>
            <div class="loyalty-details">
                <asp:Label ID="lblLoyaltyPoints" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="btnReturnHome" runat="server" Text="Return Home" CssClass="styled-button" OnClick="btnReturnHome_Click" />
        </div>
    </form>
</body>
</html>
