using System;
using System.Web.UI;

namespace YourNamespace
{
    public partial class InventoryManagerDashboard : Page
    {
        protected void btnManageInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageInventory.aspx"); 
        }

        protected void btnTrackUsage_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrackIngredientUsage.aspx"); 
        }

        protected void btnStockChecks_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConductStockChecks.aspx"); 
        }
    }
}
