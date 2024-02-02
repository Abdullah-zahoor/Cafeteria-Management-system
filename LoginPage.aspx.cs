using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DB_WEBFORM_PROJ
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; 

            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, UserRole FROM UserAccount WHERE Username = @Username AND PasswordHash = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string userRole = reader.GetString(1);

                            
                            Session["UserID"] = userId;

                            
                            switch (userRole)
                            {
                                case "Cashier":
                                    Response.Redirect("CashierDashboard.aspx");
                                    break;
                                case "Customer":
                                    Response.Redirect("CustomerDashboard.aspx");
                                    break;
                                case "Staff":
                                    Response.Redirect("StaffDashboard.aspx");
                                    break;
                                case "Inventory_Manager":
                                    Response.Redirect("InventoryManagerDashboard.aspx");
                                    break;
                                case "Cafe_Manager":
                                    Response.Redirect("CafeManagerDashboard.aspx");
                                    break;
                                case "Supplier":
                                    Response.Redirect("SupplierDashboard.aspx");
                                    break;
                                default:
                                    Response.Redirect("ErrorPage.aspx");
                                    break;
                            }
                        }
                        else
                        {
                            ShowErrorMessage("Invalid username or password.");
                        }
                    }
                }
            }
        }


        private void ShowErrorMessage(string message)
        {
        }
    }
}
