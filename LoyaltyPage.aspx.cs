using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class LoyaltyPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalculateAndDisplayLoyaltyPoints();
            }
        }

        private void CalculateAndDisplayLoyaltyPoints()
        {
            
            int userId = Convert.ToInt32(Session["UserID"]);
            int loyaltyPoints = 0;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = @"
                    SELECT COUNT(DISTINCT O.orderId) AS OrderCount
                    FROM Orders O
                    INNER JOIN orders_have_menu OHM ON O.orderId = OHM.Order_id
                    INNER JOIN Menu_Items MI ON OHM.Item_ID = MI.Item_ID
                    WHERE O.customerID = @CustomerID
                    AND O.orderDate = CAST(GETDATE() AS DATE)";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", userId);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int orderCount = (int)reader["OrderCount"];
                           
                            loyaltyPoints = orderCount > 1 ? 100 : 50;
                        }
                    }
                }
            }

           
            lblLoyaltyPoints.Text = $"You have earned {loyaltyPoints} loyalty points!";
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("CustomerDashboard.aspx"); 
        }
    }
}
