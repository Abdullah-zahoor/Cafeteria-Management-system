using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_WEBFORM_PROJ
{
    public partial class CustomerDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuItems();
            }
        }

        private void BindMenuItems()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               
                string query = @"
            SELECT MI.Item_ID, MI.Name, MI.Price, MC.Name AS CategoryName, I.Quantity
            FROM Menu_Items MI
            INNER JOIN Menu_Category MC ON MI.Category_ID = MC.Category_ID
            INNER JOIN Inventory I ON MI.Item_ID = I.inv_Item_ID
            WHERE MI.Availability = 'Available' AND I.Quantity > 0";

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


        protected void gvMenuItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMenuItems.Rows[index];
                string itemId = row.Cells[0].Text; 

                
                Session["SelectedMenuItem"] = itemId;

               
                Response.Redirect($"PaymentPage.aspx?itemID={itemId}");
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentPage.aspx");
        }
    }
}
