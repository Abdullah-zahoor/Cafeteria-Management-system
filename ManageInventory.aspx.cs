using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace DB_WEBFORM_PROJ
{
    public partial class ManageInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInventoryGrid();
            }
        }

        private void BindInventoryGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT I.inv_Item_ID, P.ProductName, I.Quantity, I.Capacity, P.Price FROM Inventory I INNER JOIN Products P ON I.inv_Item_ID = P.inv_Item_ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvInventory.DataSource = dt;
                    gvInventory.DataBind();
                }
            }
        }

        protected void gvInventory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvInventory.EditIndex = e.NewEditIndex;
            BindInventoryGrid();
        }

        protected void gvInventory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInventory.EditIndex = -1;
            BindInventoryGrid();
        }

        protected void gvInventory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvInventory.Rows[e.RowIndex];
            int invItemId = Convert.ToInt32(gvInventory.DataKeys[e.RowIndex].Value);
            string productName = (row.FindControl("txtProductName") as TextBox).Text;
            int quantity = Convert.ToInt32((row.FindControl("txtQuantity") as TextBox).Text);
            int capacity = Convert.ToInt32((row.FindControl("txtCapacity") as TextBox).Text);
            decimal price = Convert.ToDecimal((row.FindControl("txtPrice") as TextBox).Text);

            UpdateInventoryItem(invItemId, productName, quantity, capacity, price);

            gvInventory.EditIndex = -1;
            BindInventoryGrid();
        }

        protected void gvInventory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int invItemId = Convert.ToInt32(gvInventory.DataKeys[e.RowIndex].Value);
            DeleteInventoryItem(invItemId);
            BindInventoryGrid();
        }

        

        private void UpdateInventoryItem(int invItemId, string productName, int quantity, int capacity, decimal price)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string updateProductsQuery = "UPDATE Products SET ProductName = @ProductName, Price = @Price WHERE inv_Item_ID = @InvItemId";

                using (SqlCommand cmd = new SqlCommand(updateProductsQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@InvItemId", invItemId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

               
                string updateInventoryQuery = "UPDATE Inventory SET Quantity = @Quantity, Capacity = @Capacity WHERE inv_Item_ID = @InvItemId";

                using (SqlCommand cmd = new SqlCommand(updateInventoryQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@InvItemId", invItemId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            
            TextBox txtNewProductName = (TextBox)gvInventory.FooterRow.FindControl("txtNewProductName");
            TextBox txtNewQuantity = (TextBox)gvInventory.FooterRow.FindControl("txtNewQuantity");
            TextBox txtNewCapacity = (TextBox)gvInventory.FooterRow.FindControl("txtNewCapacity");
            TextBox txtNewPrice = (TextBox)gvInventory.FooterRow.FindControl("txtNewPrice");

            
            string newProductName = txtNewProductName.Text;
            int newQuantity = int.Parse(txtNewQuantity.Text);
            int newCapacity = int.Parse(txtNewCapacity.Text);
            decimal newPrice = decimal.Parse(txtNewPrice.Text);

            
            AddNewInventoryItem(newProductName, newQuantity, newCapacity, newPrice);

            
            BindInventoryGrid();
        }
        private void DeleteInventoryItem(int invItemId)
        {

        }

        private void AddNewInventoryItem(string productName, int quantity, int capacity, decimal price)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    
                    string getMaxIdQuery = "SELECT ISNULL(MAX(inv_Item_ID), 0) + 1 FROM Inventory";
                    SqlCommand cmdGetMaxId = new SqlCommand(getMaxIdQuery, con, transaction);
                    int newInventoryItemId = Convert.ToInt32(cmdGetMaxId.ExecuteScalar());
                    string getMaxProductIdQuery = "SELECT ISNULL(MAX(Product_ID), 0) + 1 FROM Products";
                    SqlCommand cmdGetMaxProductId = new SqlCommand(getMaxProductIdQuery, con, transaction);
                    int newProductId = Convert.ToInt32(cmdGetMaxProductId.ExecuteScalar());

                   
                    string insertInventoryQuery = "INSERT INTO Inventory (inv_Item_ID, Quantity, Capacity, IM_ID) VALUES (@NewInventoryID, @Quantity, @Capacity, @IMID)";
                    SqlCommand cmdInventory = new SqlCommand(insertInventoryQuery, con, transaction);
                    cmdInventory.Parameters.AddWithValue("@NewInventoryID", newInventoryItemId);
                    cmdInventory.Parameters.AddWithValue("@Quantity", quantity);
                    cmdInventory.Parameters.AddWithValue("@Capacity", capacity);
                    cmdInventory.Parameters.AddWithValue("@IMID", 1);

                    cmdInventory.ExecuteNonQuery();

                    
                    string insertProductQuery = "INSERT INTO Products (Product_ID, ProductName, Price, inv_Item_ID) VALUES (@NewProductID, @ProductName, @Price, @NewInventoryID)";
                    SqlCommand cmdProduct = new SqlCommand(insertProductQuery, con, transaction);
                    cmdProduct.Parameters.AddWithValue("@NewProductID", newProductId);
                    cmdProduct.Parameters.AddWithValue("@ProductName", productName);
                    cmdProduct.Parameters.AddWithValue("@Price", price);
                    cmdProduct.Parameters.AddWithValue("@NewInventoryID", newInventoryItemId);

                    cmdProduct.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                   
                    throw ex;
                }
            }
        }

       
    }
}
