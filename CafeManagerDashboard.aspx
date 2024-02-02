<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CafeManagerDashboard.aspx.cs" Inherits="DB_WEBFORM_PROJ.CafeManagerDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cafe Manager Dashboard</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form runat="server">
        <div class="container">
           <h2 style="text-align: center; color: #FFA500; font-size: 30px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-bottom: 20px;">Cafe Manager Dashboard</h2>



            
            <!-- Financial Reporting Section -->
           <div style="background-color: #FFF5EE; padding: 15px; margin-bottom: 15px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
    <h3 style="color: #DEB887; margin-bottom: 10px;">Financial Summary</h3>
                <asp:GridView ID="gvFinancialSummary" runat="server" CssClass="dashboard-grid"></asp:GridView>
            </div>

            <!-- Inventory Management Section -->
           <div style="background-color: #FFF0F5; padding: 15px; margin-bottom: 15px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
    <h3 style="color: #BA55D3; margin-bottom: 10px;">Inventory Status</h3>
                <asp:GridView ID="gvInventoryStatus" runat="server" CssClass="dashboard-grid"></asp:GridView>
            </div>

            <!-- Section for Menu Management -->
          <div style="background-color: #F0F8FF; padding: 15px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);">
    <h3 style="color: #1E90FF; margin-bottom: 10px;">Menu Items</h3>
             <asp:GridView ID="gvMenuItems" runat="server" CssClass="grid-view" 
                          AutoGenerateColumns="False" AutoGenerateEditButton="True" 
                          DataKeyNames="Item_ID"
                          OnRowEditing="gvMenuItems_RowEditing" 
                          OnRowUpdating="gvMenuItems_RowUpdating"
                          OnRowCancelingEdit="gvMenuItems_RowCancelingEdit">
                    <Columns>
                        <asp:BoundField DataField="Item_ID" HeaderText="Item ID" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Bind("MenuItem") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("MenuItem") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

       
        <asp:TemplateField HeaderText="Price">
            <ItemTemplate>
                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Availability">
    <ItemTemplate>
        <asp:Label ID="lblAvailability" runat="server" Text='<%# Bind("Availability") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtAvailability" runat="server" Text='<%# Bind("Availability") %>'></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

                        <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" /> 
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
