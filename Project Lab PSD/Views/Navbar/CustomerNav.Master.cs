using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Navbar
{
    public partial class CustomerNav : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void stationeries_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Customer/CustomerStationeryPage.aspx");
        }

        protected void cart_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Customer/CustomerCartPage.aspx");
        }

        protected void transactionsHistory_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Customer/CustomerTransactionHistoryPage.aspx");
        }

        protected void profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Customer/CustomerProfilePage.aspx");
        }
    }
}