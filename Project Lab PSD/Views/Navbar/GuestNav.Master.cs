using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Navbar
{
    public partial class GuestNav : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void stationeries_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest/GuestStationeryPage.aspx");
        }

        protected void register_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest/GuestRegisterPage.aspx");
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Guest/GuestLoginPage.aspx");
        }
    }
}