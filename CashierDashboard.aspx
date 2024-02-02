<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashierDashboard.aspx.cs" Inherits="DB_WEBFORM_PROJ.CashierDashboard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cashier Dashboard</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div class="container">
            <h2 style="color: orange; text-align: center;">Cashier Dashboard</h2>

            <div class="dashboard-section">
                <h3>Record New Transaction</h3>
                <asp:DropDownList ID="ddlMenuItems" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMenuItems_SelectedIndexChanged">
                  
                </asp:DropDownList>
                <asp:Label ID="lblItemPrice" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtAmountPaid" runat="server" placeholder="Amount Paid"></asp:TextBox>
                <asp:Button ID="btnGenerateReceipt" runat="server" Text="Generate Receipt" OnClick="btnGenerateReceipt_Click" />
            </div>

            <!-- Transactions Section -->
            <div class="dashboard-section">
                <h3>Recent Transactions</h3>
                <asp:GridView ID="gvRecentTransactions" runat="server" AutoGenerateColumns="False" CssClass="dashboard-grid">
                    <Columns>
                        <asp:BoundField DataField="Transaction_ID" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                        <asp:BoundField DataField="OrderStatus" HeaderText="Order Status" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        function printReceipt() {
            window.print();
        }
    </script>
</body>
</html>
