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

namespace Project_Lab_PSD.Views.Customer
{
    public partial class CustomerCartPage : System.Web.UI.Page
    {
        CustomerController customerCont = new CustomerController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = 2;
                
                Response<List<CartDisplayModel>> response = customerCont.ViewCarts(userID);
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

            string stringId = row.Cells[0].Text.ToString();

            int id = 0;

            int.TryParse(stringId, out id);

            Response.Redirect($"CartUpdate.aspx?CartID={id}");
        }

        protected void cartGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = 2;

            GridViewRow row = cartGrid.Rows[e.RowIndex];

            string stringId = row.Cells[0].Text.ToString();

            int id = 0;

            int.TryParse(stringId, out id);

            Response<Cart> deleteResponse = customerCont.DeleteCart(userID, id);

            Response.Redirect($"CustomerCartPage.aspx");
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            int userID = 2;
            Response<List<Cart>> response = customerCont.OrderStationeries(userID);
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