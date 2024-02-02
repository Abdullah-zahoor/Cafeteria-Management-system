<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackIngredientUsage.aspx.cs" Inherits="DB_WEBFORM_PROJ.TrackIngredientUsage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Track Ingredient Usage</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }
        .grid-view th {
            background-color: #4CAF50;
            color: white;
            padding: 8px;
            border: 1px solid #ddd;
        }
        .grid-view td {
            padding: 8px;
            border: 1px solid #ddd;
        }
        .grid-view tr:nth-child(even) {background-color: #f2f2f2;}
        .grid-view tr:hover {background-color: #ddd;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="color: orange;">Ingredient Usage</h2>
            <asp:GridView ID="gvIngredientUsage" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="inv_Item_ID" HeaderText="Inventory Item ID" ReadOnly="True" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="MenuItem" HeaderText="Menu Item" />
                    <asp:BoundField DataField="UsageCount" HeaderText="Usage Count" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
