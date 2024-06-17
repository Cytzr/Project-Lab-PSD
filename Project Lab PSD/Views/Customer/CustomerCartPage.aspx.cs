using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Customer
{
    public partial class CustomerCartPage : System.Web.UI.Page
    {
        CustomerHandler customerHandler = new CustomerHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
           
                Response<List<CartDisplayModel>> response = customerHandler.ViewCarts(userID);
                cartGrid.DataSource = response.PassValue;

                if (response != null)
                {
                    cartGrid.DataBind();
                }
                else
                {
                    Console.WriteLine("No Data");
                }
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Request.Cookies["user_cookie"].Value);
            Response<List<Cart>> response = customerHandler.OrderStationeries(userID);
            if(response.IsSuccess)
            {
                Response.Redirect("~/Views/Customer/CustomerTransactionHistory.aspx");
            } else
            {
                lbl_error.Text = response.Message;
            }
        }
    }
}