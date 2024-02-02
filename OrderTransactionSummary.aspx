<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderTransactionSummary.aspx.cs" Inherits="DB_WEBFORM_PROJ.OrderTransactionSummary" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order & Transaction Summary</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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
            <h2>Order & Transaction Summary</h2>
         <asp:GridView ID="gvOrderTransactionSummary" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="Order ID" ReadOnly="True" />
                <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="First_name" HeaderText="Customer First Name" />
                <asp:BoundField DataField="Last_name" HeaderText="Customer Last Name" />
                <asp:BoundField DataField="MenuItemName" HeaderText="Menu Item" />
                <asp:BoundField DataField="Status" HeaderText="Transaction Status" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Amount" HeaderText="Transaction Amount" DataFormatString="{0:C}" />
            </Columns>

              </asp:GridView>

        </div>
    </form>
</body>
</html>
