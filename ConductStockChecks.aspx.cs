using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class ConductStockChecks : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInventoryGrid();
                BindMenuItemsGrid();
            }
        }

        private void BindInventoryGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT I.inv_Item_ID, P.ProductName, I.Quantity, I.Capacity, P.Price, S.Name AS SupplierName
            FROM Inventory I
            INNER JOIN Products P ON I.inv_Item_ID = P.inv_Item_ID
            LEFT JOIN Supplies SUP ON P.Product_ID = SUP.Product_ID
            LEFT JOIN Supplier S ON SUP.Supplier_ID = S.Supplier_ID
            ORDER BY P.ProductName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvInventory.DataSource = dt;
                    gvInventory.DataBind();
                }
            }
        }


        private void BindMenuItemsGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT MI.Item_ID, MI.Name, MI.Availability, MI.Price, MC.Name AS CategoryName, 
                   (SELECT COUNT(*) FROM orders_have_menu OHM WHERE OHM.Item_ID = MI.Item_ID) AS OrderCount
            FROM Menu_Items MI
            INNER JOIN Menu_Category MC ON MI.Category_ID = MC.Category_ID
            ORDER BY MI.Name";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvMenuItems.DataSource = dt;
                    gvMenuItems.DataBind();
                }
            }
        }

    }
}
