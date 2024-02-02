<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConductStockChecks.aspx.cs" Inherits="DB_WEBFORM_PROJ.ConductStockChecks" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Conduct Stock Checks</title>
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
            background-color: #f2f2f2;
        }
        
        .grid-view tr:hover {background-color: #ddd;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="color: orange;">Stock Check - Inventory</h2>
            <asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="inv_Item_ID" HeaderText="Item ID" ReadOnly="True" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier" />
                </Columns>
            </asp:GridView>

            <h2 style="color: orange; margin-top: 20px;">Stock Check - Menu Items</h2>
            <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="Item_ID" HeaderText="Item ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Item Name" />
                    <asp:BoundField DataField="Availability" HeaderText="Availability" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="OrderCount" HeaderText="Order Count" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
