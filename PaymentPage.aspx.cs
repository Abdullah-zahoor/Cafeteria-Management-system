using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class PaymentPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal totalAmount = GetTotalAmount();
                lblTotalAmount.Text = "Total Amount: " + totalAmount.ToString("C");
            }
        }

        private decimal GetTotalAmount()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectedItemId = Session["SelectedMenuItem"] as string;

                if (string.IsNullOrEmpty(selectedItemId))
                {
                    return 0;
                }

                string query = "SELECT Price FROM Menu_Items WHERE Item_ID = @ItemId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemId", selectedItemId);
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        
                        return 0;
                    }
                }
            }
        }


        protected void btnPayNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoyaltyPage.aspx");
        }
    }
}
