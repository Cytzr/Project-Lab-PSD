using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
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
            if (Session["user"] == null && Response.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/GuestLoginPage.aspx");
                return;
            }
            if (Session["user"] == null)
            {
                String cook = Response.Cookies["user_cookie"].Value;
                UserRepository user = new UserRepository();
                MsUser us = user.GetByUserName(cook);
                if (us == null)
                {
                    Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(1);
                    Response.Redirect("~/Views/GuestLoginPage.aspx");
                    return;
                }
                Session["user"] = us;
            }
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