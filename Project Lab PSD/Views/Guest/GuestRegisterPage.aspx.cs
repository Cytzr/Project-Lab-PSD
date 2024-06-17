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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string reEnterPassword = txtPasswordConfirm.Text;
            System.DateTime date = DateTime.Parse(dateValue.Text);
            string gender = txtGender.Text;
            string role = txtRole.Text;
            if(password != reEnterPassword)
            {
                lblMessage.Text = "Password is not the same";
            } else
            {
                GuestHandler guestHandler = new GuestHandler();
                Response<MsUser> response = guestHandler.Register(userName, gender, date, phone, address, password, role);
                MsUser user = response.PassValue;
                if (response.IsSuccess == false)
                {

                    lblMessage.Text = response.Message;
                }
                else if(response.IsSuccess == true)
                {
                    Response.Redirect("~/Views/Guest/GuestLoginPage.aspx");
                }
            }

            
        }
    }
}