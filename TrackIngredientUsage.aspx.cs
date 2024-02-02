using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class TrackIngredientUsage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIngredientUsageGrid();
            }
        }

        private void BindIngredientUsageGrid()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = @"
                    SELECT I.inv_Item_ID, P.ProductName, I.Quantity, MI.Name as MenuItem, COUNT(OHM.Order_id) as UsageCount
                    FROM Inventory I
                    INNER JOIN Products P ON I.inv_Item_ID = P.inv_Item_ID
                    INNER JOIN Menu_Items MI ON P.Product_ID = MI.Item_ID
                    LEFT JOIN orders_have_menu OHM ON MI.Item_ID = OHM.Item_ID
                    GROUP BY I.inv_Item_ID, P.ProductName, I.Quantity, MI.Name
                    ORDER BY P.ProductName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvIngredientUsage.DataSource = dt;
                    gvIngredientUsage.DataBind();
                }
            }
        }
    }
}
