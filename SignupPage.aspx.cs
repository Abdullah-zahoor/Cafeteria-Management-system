using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace DB_WEBFORM_PROJ
{
    public partial class SignupPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can implement any page initialization logic here
        }
        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            pnlStaff.Visible = false;
            pnlCashier.Visible = false;
            pnlCafeManager.Visible = false;
            pnlInventoryManager.Visible = false;
            pnlCustomer.Visible = false;
            pnlSupplier.Visible = false;


            switch (ddlUserType.SelectedValue)
            {
                case "Staff":
                    pnlStaff.Visible = true;
                    break;
                case "Cashier":
                    pnlCashier.Visible = true;
                    break;
                case "Cafe_Manager":
                    pnlCafeManager.Visible = true;
                    break;
                case "Inventory_Manager":
                    pnlInventoryManager.Visible = true;
                    break;
                case "Customer":
                    pnlCustomer.Visible = true;
                    break;
                case "Supplier":
                    pnlSupplier.Visible = true;
                    break;
                default:
                    
                    break;
            }
        }
        private void ShowErrorMessage(string message)
        {

        }
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text; 
            string confirmPassword = txtConfirmPassword.Text;
            string selectedUserRole = ddlUserType.SelectedValue; 

            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || selectedUserRole == "Select User Type")
            {
                ShowErrorMessage("All fields are required.");
                return;
            }

            if (password != confirmPassword)
            {
                ShowErrorMessage("Passwords do not match.");
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    string query = "INSERT INTO UserAccount (Username, PasswordHash, Email, UserRole) VALUES (@Username, @Password, @Email, @UserRole)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password); 
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@UserRole", selectedUserRole);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                
                Response.Redirect("LoginPage.aspx");
            }
            catch (SqlException ex)
            {
                
                ShowErrorMessage("A user with this username or email already exists.");
            }
            catch (Exception ex)
            {
               
                ShowErrorMessage("An error occurred during registration. Please try again.");
            }
        }

       
    }
}
