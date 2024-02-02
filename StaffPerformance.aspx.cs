using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class StaffPerformance : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStaffPerformanceData();
            }
        }

        private void BindStaffPerformanceData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = @"
                    SELECT S.Staff_ID AS StaffID, S.Name AS StaffName, 
                           COUNT(T.Transaction_ID) AS TotalTransactions, 
                           AVG(F.Rating) AS AverageRating
                    FROM Staff S
                    LEFT JOIN Transactions T ON S.Staff_ID = T.CashierID
                    LEFT JOIN Feedbacks F ON S.Staff_ID = F.CM_ID
                    GROUP BY S.Staff_ID, S.Name";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvStaffPerformance.DataSource = dt;
                    gvStaffPerformance.DataBind();
                }
            }
        }
    }
}
