<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryManagerDashboard.aspx.cs" Inherits="YourNamespace.InventoryManagerDashboard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventory Manager Dashboard</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="color: orange;">Inventory Manager Dashboard</h2>
            <asp:Button ID="btnManageInventory" runat="server" Text="Manage Inventory" CssClass="dashboard-button" OnClick="btnManageInventory_Click" />
            <asp:Button ID="btnTrackUsage" runat="server" Text="Track Ingredient Usage" CssClass="dashboard-button" OnClick="btnTrackUsage_Click" />
            <asp:Button ID="btnStockChecks" runat="server" Text="Conduct Stock Checks" CssClass="dashboard-button" OnClick="btnStockChecks_Click" />
        </div>
    </form>
</body>
</html>
