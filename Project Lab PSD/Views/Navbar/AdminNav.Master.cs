using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Navbar
{
    public partial class AdminNav : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void stationeries_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/AdminStationeryPage.aspx");
        }

        protected void transactionReport_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/AdminTransactionReportPage.aspx");
        }

        protected void profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/AdminProfilePage.aspx");
        }

        protected void logout_btn_Click(object sender, EventArgs e)
        {

        }
    }
}