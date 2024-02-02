<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="DB_WEBFORM_PROJ.SignupPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup - CampusBites</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
     <style>
      h2 {
            color: orange;
            margin-bottom: 20px;
        }
    </style>

</head>
<body>
    <form runat="server">
        <div class="container">
            <h2>Signup</h2>

            <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                <asp:ListItem Text="Select User Type" Value=""></asp:ListItem>
                <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                <asp:ListItem Text="Cashier" Value="Cashier"></asp:ListItem>
                <asp:ListItem Text="Cafe Manager" Value="Cafe_Manager"></asp:ListItem>
                <asp:ListItem Text="Inventory Manager" Value="Inventory_Manager"></asp:ListItem>
                <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                <asp:ListItem Text="Supplier" Value="Supplier"></asp:ListItem> 
            </asp:DropDownList>
           
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>


            <asp:Panel ID="pnlStaff" runat="server" Visible="false">
                
                <asp:TextBox ID="txtStaffName" runat="server" placeholder="Name"></asp:TextBox>
            
            </asp:Panel>

            <asp:Panel ID="pnlCashier" runat="server" Visible="false">
              
            </asp:Panel>

            <asp:Panel ID="pnlCafeManager" runat="server" Visible="false">
               
            </asp:Panel>

            <asp:Panel ID="pnlInventoryManager" runat="server" Visible="false">
               
            </asp:Panel>

            <asp:Panel ID="pnlCustomer" runat="server" Visible="false">
               
                <asp:TextBox ID="txtCustomerFirstName" runat="server" placeholder="First Name"></asp:TextBox>
                <asp:TextBox ID="txtCustomerLastName" runat="server" placeholder="Last Name"></asp:TextBox>
               
            </asp:Panel>

             <asp:Panel ID="pnlSupplier" runat="server" Visible="false">
                </asp:Panel>


            <div class="button-container">
                <asp:Button ID="btnSignup" runat="server" Text="Signup" CssClass="styled-button" OnClick="btnSignup_Click" />
            </div>
        </div>
    </form>
</body>
</html>
