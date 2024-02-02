using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DB_WEBFORM_PROJ
{
    public partial class CafeManagerDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFinancialSummary();
                LoadInventoryStatus();
                LoadMenuItems();
            }
        }

        private void LoadFinancialSummary()
        {
            // Summarize total sales by date
            string query = @"
        SELECT CAST(T.Date AS Date) AS SaleDate, SUM(O.price) AS TotalSales
        FROM Transactions T
        JOIN Orders O ON T.Transaction_ID = O.PaymentID
        GROUP BY CAST(T.Date AS Date)
        ORDER BY SaleDate DESC";

            gvFinancialSummary.DataSource = ExecuteQuery(query);
            gvFinancialSummary.DataBind();
        }

        private void LoadInventoryStatus()
        {
            // Show current inventory status
            string query = @"
        SELECT P.ProductName, I.Quantity, I.Capacity
        FROM Inventory I
        JOIN Products P ON I.inv_Item_ID = P.Product_ID
        ORDER BY P.ProductName";

            gvInventoryStatus.DataSource = ExecuteQuery(query);
            gvInventoryStatus.DataBind();
        }


        private void LoadMenuItems()
        {
            
            string query = @"
        SELECT MI.Item_ID, MI.Name AS MenuItem, MI.Price, MC.Name AS CategoryName,MI.Availability
        FROM Menu_Items MI
        JOIN Menu_Category MC ON MI.Category_ID = MC.Category_ID
        ORDER BY MC.Name, MI.Name";

            gvMenuItems.DataSource = ExecuteQuery(query);
            gvMenuItems.DataBind();
        }

        protected void gvMenuItems_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMenuItems.EditIndex = e.NewEditIndex;
            LoadMenuItems();
        }

        protected void gvMenuItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            int itemId = Convert.ToInt32(gvMenuItems.DataKeys[e.RowIndex].Value);

           
            GridViewRow row = gvMenuItems.Rows[e.RowIndex];
            string updatedName = (row.FindControl("txtName") as TextBox).Text;
            string updatedAvailability = (row.FindControl("txtAvailability") as TextBox).Text;
            string updatedPrice = (row.FindControl("txtPrice") as TextBox).Text;

            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string updateQuery = @"
            UPDATE Menu_Items
            SET Name = @Name, Availability = @Availability, Price = @Price
            WHERE Item_ID = @ItemID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                   
                    cmd.Parameters.AddWithValue("@Name", updatedName);
                    cmd.Parameters.AddWithValue("@Availability", updatedAvailability);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(updatedPrice));
                    cmd.Parameters.AddWithValue("@ItemID", itemId);

                    con.Open();
                    cmd.ExecuteNonQuery(); 
                }
            }

            gvMenuItems.EditIndex = -1; 
            LoadMenuItems(); 
        }


        protected void gvMenuItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMenuItems.EditIndex = -1;
            LoadMenuItems();
        }


        private DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}