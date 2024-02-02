using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace DB_WEBFORM_PROJ
{
    public partial class CashierDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRecentTransactions();
                BindMenuItems();
            }
        }

        private void BindRecentTransactions()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

            if (Session["UserID"] != null)
            {
                int userId = Convert.ToInt32(Session["UserID"]);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    string query = @"
                    SELECT T.Transaction_ID, T.Amount, T.Date, C.First_name + ' ' + C.Last_name AS CustomerName
                    FROM Transactions T
                    INNER JOIN Payments P ON T.Transaction_ID = P.PaymentID
                    INNER JOIN Orders O ON O.PaymentID = P.PaymentID
                    INNER JOIN Customers C ON O.customerID = C.CustomerID
                    WHERE P.staffID = @UserID AND T.Status = 'Completed'
                    ORDER BY T.Date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        gvRecentTransactions.DataSource = dt;
                        gvRecentTransactions.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }

        }
        private void BindMenuItems()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Item_ID, Name FROM Menu_Items WHERE Availability = 'Available' ORDER BY Name";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlMenuItems.DataTextField = "Name";
                    ddlMenuItems.DataValueField = "Item_ID";
                    ddlMenuItems.DataSource = reader;
                    ddlMenuItems.DataBind();
                }
            }
            ddlMenuItems.Items.Insert(0, new ListItem("--Select Item--", "0"));
        }
        protected void ddlMenuItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(ddlMenuItems.SelectedValue);
            lblItemPrice.Text = GetItemPrice(itemId).ToString("C");
        }
        protected void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
           
            int itemId = Convert.ToInt32(ddlMenuItems.SelectedValue);
            decimal itemPrice = GetItemPrice(itemId);
            int orderId = GetOrderIdForItem(itemId);
           
            decimal amountPaid = Convert.ToDecimal(txtAmountPaid.Text);

            
            decimal change = amountPaid - itemPrice;

            if (change < 0)
            {
                
                ShowErrorMessage("Insufficient amount paid.");
                return;
            }

            int cashierId = Session["UserID"] != null ? Convert.ToInt32(Session["UserID"]) : -1;
            if (cashierId == -1)
            {
                
                ShowErrorMessage("Cashier ID not found. Please log in again.");
                return;
            }

           
            RecordTransaction(amountPaid, change, cashierId, orderId);

            
            var receiptDetails = new ReceiptDetails
            {
                
                ItemPrice = GetItemPrice(itemId),
                AmountPaid = amountPaid,
                Change = amountPaid - itemPrice
            };

           
            Session["ReceiptDetails"] = receiptDetails;


            Response.Redirect("ReceiptPage.aspx");
        }


        private decimal GetItemPrice(int itemId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Price FROM Menu_Items WHERE Item_ID = @ItemId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }
       

        private void RecordTransaction(decimal amountPaid, decimal change, int cashierId, int orderId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int nextTransactionId = GetNextTransactionId();
                
                string insertQuery = @"
        INSERT INTO Transactions (Transaction_ID, Transaction_type, Amount, Date, Status, CM_ID, SupplierID)
        VALUES (@TransactionID, @Type, @Amount, GETDATE(), @Status, @CMID, @SupplierID)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    
                    cmd.Parameters.AddWithValue("@TransactionID", nextTransactionId);
                    cmd.Parameters.AddWithValue("@Type", "Sale");
                    cmd.Parameters.AddWithValue("@Amount", amountPaid);
                    cmd.Parameters.AddWithValue("@Status", "Completed");
                    cmd.Parameters.AddWithValue("@CMID", DBNull.Value); 
                    cmd.Parameters.AddWithValue("@SupplierID", DBNull.Value); 

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                
                UpdateOrderPaymentStatus(orderId);
            }
        }

        private int GetNextTransactionId()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(Transaction_ID) FROM Transactions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        return 1; 
                    }
                }
            }
        }

        private void UpdateOrderPaymentStatus(int orderId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE Orders SET staatus = 'Paid' WHERE orderId = @OrderID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private string GenerateReceiptDetails(decimal amountPaid, decimal totalAmount, decimal change)
        {
            return $"Total Amount: {totalAmount:C}\n" +
                   $"Amount Paid: {amountPaid:C}\n" +
                   $"Change: {change:C}";
        }
        private void ShowErrorMessage(string message)
        {
           
        }

        private int GetOrderIdForItem(int itemId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               
                string query = @"
            SELECT TOP 1 O.orderId 
            FROM Orders O
            INNER JOIN orders_have_menu OHM ON O.orderId = OHM.Order_id
            WHERE OHM.Item_ID = @ItemId
            ORDER BY O.orderDate DESC, O.orderTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemId", itemId);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                       
                        return -1;
                    }
                }
            }
        }

    }
}

public class ReceiptDetails
{
    
    public decimal ItemPrice { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal Change { get; set; }
}
