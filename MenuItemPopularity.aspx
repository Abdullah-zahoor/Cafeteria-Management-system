<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuItemPopularity.aspx.cs" Inherits="DB_WEBFORM_PROJ.MenuItemPopularity" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Item Popularity</title>
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
         h2 {
            color: orange;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Menu Item Popularity</h2>
        <asp:GridView ID="gvMenuItemPopularity" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
           <Columns>
                    <asp:BoundField DataField="Item_ID" HeaderText="Item ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Item Name" />
                    <asp:BoundField DataField="OrderCount" HeaderText="Order Count" />
                </Columns>
        </asp:GridView>
    </form>
</body>
</html>
