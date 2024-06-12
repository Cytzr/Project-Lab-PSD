using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            if (response.IsSuccess == false)
            {
                lblMessage.Text = response.Message;
            } else
            {
                Response.Redirect("~/Views/Guest/GuestStationeryPage.aspx");
            }

        }
    }
}