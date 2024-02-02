<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptPage.aspx.cs" Inherits="DB_WEBFORM_PROJ.ReceiptPage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receipt</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
       <div class="container" style="background-color: white; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); max-width: 600px; margin: auto;">
        <!-- Receipt Details -->
        <div id="receipt" style="text-align: left; font-family: Arial, sans-serif; color: #333;">
            <h2 style="color: #D32F2F;">Receipt Details</h2>
            <hr style="border-top: 1px solid #ddd;">
            <asp:Label ID="lblReceiptDetails" runat="server" style="font-size: 16px; line-height: 1.6;"></asp:Label>
        </div>

        <!-- Print Button -->
        <div style="margin-top: 20px; text-align: center;">
            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="window.print(); return false;" style="background-color: #D32F2F; color: white; border: none; padding: 10px 20px; font-size: 16px; border-radius: 5px; cursor: pointer;" />
        </div>
    </div>
    </form>
</body>
</html>
