<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPerformance.aspx.cs" Inherits="DB_WEBFORM_PROJ.StaffPerformance" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Performance</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
        }

        .container {
            width: 80%;
            margin: 0 auto;
            text-align: center;
        }

        .grid-view {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        .grid-view th {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
        }

        .grid-view td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        h2 {
            color: orange;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Staff Performance Overview</h2>
            <asp:GridView ID="gvStaffPerformance" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="StaffID" HeaderText="Staff ID" ReadOnly="True" />
                    <asp:BoundField DataField="StaffName" HeaderText="Staff Name" />
                    <asp:BoundField DataField="TotalTransactions" HeaderText="Total Transactions" />
                    <asp:BoundField DataField="AverageRating" HeaderText="Average Rating" DataFormatString="{0:N2}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
