<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="DB_WEBFORM_PROJ.CustomerDashboard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
     <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>Customer Dashboard</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            width: 80%;
            margin: 0 auto;
            text-align: center;
        }
        h2 {
            color: #4CAF50;
            margin-bottom: 20px;
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
        }
        .grid-view th {
            background-color: #4CAF50;
            color: white;
            padding: 15px;
            text-align: left;
        }
        .grid-view td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
            background-color: #fff;

        }
        .grid-view tr:nth-child(even) {background-color: #f2f2f2;}
        .grid-view tr:hover {background-color: #ddd;}
        .styled-button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }
        .styled-button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Menu Selection</h2>
            <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False" OnRowCommand="gvMenuItems_RowCommand" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="Item_ID" HeaderText="Item ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Item Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="Quantity" HeaderText="Available Quantity" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" CommandName="SelectItem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Select" CssClass="styled-button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="styled-button" />
        </div>
    </form>
</body>
</html>
