using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Customer
{
    public partial class CustomerProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            oldUsername.Text = user.UserName;
            oldPhone.Text = user.UserPhone;
            oldAddress.Text = user.UserAddress;
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            string userName = newUserName.Text;
            string password = newPassword.Text;
            string address = newAddress.Text;
            string phone = newPhone.Text;
            string reEnterPassword = newPasswordConfirm.Text;
            string gender = newGender.Text;
            string dob = dateValue.Text;
            UserRepository users = new UserRepository();
            Debug.WriteLine(userName);
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(reEnterPassword) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(dob))
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
            MsUser newUser = new MsUser()
            {
                UserName = userName,
                UserGender = gender,
                UserDOB = dateOfBirth,
                UserPhone = phone,
                UserAddress = address,
                UserPassword = password,
            };
            CustomerHandler customerHandler = new CustomerHandler();
            Response<MsUser> response = customerHandler.UpdateProfileByID(user.UserID, newUser);
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