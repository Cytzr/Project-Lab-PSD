using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
            string gender = txtGender.Text;
            string role = txtRole.Text;

            UserRepository users = new UserRepository();
            Debug.WriteLine(userName);
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(reEnterPassword)  ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(role))
            {
                lblMessage.Text = "Please fill in all required fields.";
                return;
            }

          
            if (userName.Length < 5 || userName.Length > 50)
            {
                lblMessage.Text = "Username must be between 5 and 50 characters.";
                return;
            }
            if (password != reEnterPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }
            Regex alphanumericRegex = new Regex("^[a-zA-Z0-9]*$");
            if (!alphanumericRegex.IsMatch(password))
            {
                lblMessage.Text = "Password must be alphanumeric.";
                return;
            }

            if (!DateTime.TryParse(dateValue.Text, out DateTime dateOfBirth) ||
                (DateTime.Now - dateOfBirth).TotalDays < 365)
            {
                lblMessage.Text = "You must be at least 1 year old.";
                return;
            }

         
            if (users.GetByUserName(userName) != null)
            {
                lblMessage.Text = "Username is already in use.";
                return;
            }

            GuestHandler guestHandler = new GuestHandler();
            Response<MsUser> response = guestHandler.Register(userName, gender, dateOfBirth, phone, address, password, role);
            MsUser user = response.PassValue;
            if (response.IsSuccess)
            {
                Response.Redirect("~/Views/Guest/GuestLoginPage.aspx");
            }
            else
            {
                lblMessage.Text = response.Message;
            }
        }
    }
}