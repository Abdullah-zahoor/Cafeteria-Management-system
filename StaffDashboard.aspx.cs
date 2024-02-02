using System;
using System.Web.UI;

namespace DB_WEBFORM_PROJ
{
    public partial class StaffDashboard : Page
    {
        protected void btnStaffPerformance_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffPerformance.aspx"); 
        }

        protected void btnOrderTransactionSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderTransactionSummary.aspx");
        }

        protected void btnMenuItemPopularity_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuItemPopularity.aspx"); 
        }
    }
}
