using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class MenuItemPopularity : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuItemPopularityData();
            }
        }

        private void BindMenuItemPopularityData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = @"
                SELECT MI.Item_ID, MI.Name,COALESCE(OrderCounts.OrderCount, 0) AS OrderCount
                FROM Menu_Items MI LEFT JOIN 
                (SELECT OH.Item_ID, COUNT(OH.Order_id) AS OrderCount
                FROM orders_have_menu OH GROUP BY OH.Item_ID) 
                AS OrderCounts ON MI.Item_ID = OrderCounts.Item_ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvMenuItemPopularity.DataSource = dt;
                    gvMenuItemPopularity.DataBind();
                }
            }
        }

    }
}
