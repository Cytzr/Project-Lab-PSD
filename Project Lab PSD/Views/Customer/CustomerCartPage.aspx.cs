using Project_Lab_PSD.Controllers;
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
using System.Xml.Linq;

namespace Project_Lab_PSD.Views.Customer
{
    public partial class CustomerCartPage : System.Web.UI.Page
    {
        CustomerController customerController = new CustomerController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);

                Response<List<CartDisplayModel>> response = customerController.ViewCarts(userID);
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

        protected void cartGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = cartGrid.Rows[e.RowIndex];

            string name = row.Cells[0].Text.ToString();

            Response<MsStationery> response = customerController.GetStationaryByName(name);

            string ID = response.PassValue.StationeryID.ToString();

            Response.Redirect($"CartUpdate.aspx?CartID={ID}");
        }

        protected void cartGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);

            GridViewRow row = cartGrid.Rows[e.RowIndex];

            string name = row.Cells[0].Text.ToString();

            Response<MsStationery> response = customerController.GetStationaryByName(name);

            int id = response.PassValue.StationeryID;

            Response<Cart> deleteResponse = customerController.DeleteCart(userID, id);

            Response.Redirect($"CustomerCartPage.aspx");
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
            Response<List<Cart>> response = customerController.OrderStationeries(userID);
            if(response.IsSuccess)
            {
                Response.Redirect("~/Views/Customer/CustomerTransactionHistoryPage.aspx");
            } else
            {
                lbl_error.Text = response.Message;
            }
        }
    }
}