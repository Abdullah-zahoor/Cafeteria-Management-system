<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageInventory.aspx.cs" Inherits="DB_WEBFORM_PROJ.ManageInventory" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Inventory</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .grid-view {
            width: 100%;
            border-collapse: collapse;
             background-color: DodgerBlue;
        }
        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .grid-view th {
            background-color: #4CAF50;
            color: white;
        }
        .footer-template input[type="text"] {
            width: 100%;
        }
        .footer-template input[type="text"]::placeholder {
            color: #999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2 style="color: orange;">Inventory Management</h2>
        <asp:GridView ID="gvInventory" runat="server" AutoGenerateColumns="False" DataKeyNames="inv_Item_ID"
            OnRowEditing="gvInventory_RowEditing" OnRowUpdating="gvInventory_RowUpdating" 
            OnRowDeleting="gvInventory_RowDeleting" OnRowCancelingEdit="gvInventory_RowCancelingEdit" 
            ShowFooter="True" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="inv_Item_ID" HeaderText="Item ID" ReadOnly="True" />
                
                <asp:TemplateField HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Capacity">
                    <ItemTemplate>
                        <asp:Label ID="lblCapacity" runat="server" Text='<%# Eval("Capacity") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCapacity" runat="server" Text='<%# Bind("Capacity") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                
                <asp:TemplateField>
                   <FooterTemplate>
                        <asp:TextBox ID="txtNewProductName" runat="server" CssClass="footer-template" Placeholder="Enter Product Name" />
                        <asp:TextBox ID="txtNewQuantity" runat="server" CssClass="footer-template" Placeholder="Enter Quantity" />
                        <asp:TextBox ID="txtNewCapacity" runat="server" CssClass="footer-template" Placeholder="Enter Capacity" />
                        <asp:TextBox ID="txtNewPrice" runat="server" CssClass="footer-template" Placeholder="Enter Price" />
                        <asp:Button ID="btnAddNew" runat="server" Text="Add" OnClick="btnAddNew_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
