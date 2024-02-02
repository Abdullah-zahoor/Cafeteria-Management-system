using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace DB_WEBFORM_PROJ
{
    public partial class ReceiptPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ReceiptDetails"] is ReceiptDetails receiptDetails)
                {
                    lblReceiptDetails.Text = GenerateReceipt( receiptDetails.ItemPrice, receiptDetails.AmountPaid, receiptDetails.Change);
                }
                else
                {
                    lblReceiptDetails.Text = "No receipt details available.";
                }
            }
        }

        private string GenerateReceipt(decimal itemPrice, decimal amountPaid, decimal change)
        {
            return $"Receipt\n\n Item Price: {itemPrice:C}\nAmount Paid: {amountPaid:C}\nChange: {change:C}";
        }


    }
}

