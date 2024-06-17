using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.PerformanceData;
using System.EnterpriseServices.CompensatingResourceManager;

namespace Project_Lab_PSD.Views.Guest
{
    public partial class LoginPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            
            GuestHandler guestHandler = new GuestHandler();
            Response<MsUser> response = guestHandler.Login(userName, password);
            MsUser user = response.PassValue;
            if (response.IsSuccess == false)
            {

                lblMessage.Text = response.Message;
            }
            else
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = user.UserName;
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                Session["user"] = user;
                if (user.UserRole == "customer")
                {
                    Response.Redirect("~/Views/Customer/CustomerStationeryPage.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/Admin/AdminStationeryPage.aspx");
                }

            }

        }
    }
}