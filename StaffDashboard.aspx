<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="DB_WEBFORM_PROJ.StaffDashboard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Dashboard</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="color: orange;">Staff Dashboard</h2>
            <asp:Button ID="btnStaffPerformance" runat="server" Text="Staff Performance" CssClass="dashboard-button" OnClick="btnStaffPerformance_Click" />
            <asp:Button ID="btnOrderTransactionSummary" runat="server" Text="Order and Transaction Summary" CssClass="dashboard-button" OnClick="btnOrderTransactionSummary_Click" />
            <asp:Button ID="btnMenuItemPopularity" runat="server" Text="Menu Item Popularity" CssClass="dashboard-button" OnClick="btnMenuItemPopularity_Click" />
        </div>
    </form>
</body>
</html>
