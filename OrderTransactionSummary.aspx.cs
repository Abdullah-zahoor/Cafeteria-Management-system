using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class OrderTransactionSummary : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrderTransactionData();
            }
        }

        private void BindOrderTransactionData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                O.orderId,O.price, C.First_name, C.Last_name, MI.Name AS MenuItemName, T.Status, T.Date AS TransactionDate, T.Amount
                FROM Orders O
                LEFT JOIN Customers C ON O.customerID = C.CustomerID
                LEFT JOIN orders_have_menu OHM ON O.orderId = OHM.Order_id
                LEFT JOIN Menu_Items MI ON OHM.Item_ID = MI.Item_ID
                LEFT JOIN trans_products TP ON MI.Item_ID = TP.Product_ID
                LEFT JOIN Transactions T ON TP.Transacion_ID = T.Transaction_ID
                ";



                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvOrderTransactionSummary.DataSource = dt;
                    gvOrderTransactionSummary.DataBind();
                }
            }
        }

    }
}







