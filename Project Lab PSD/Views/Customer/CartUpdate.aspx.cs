using Project_Lab_PSD.Controllers;
using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Customer
{
    public partial class CartUpdate : System.Web.UI.Page
    {
        CustomerController customerController = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
                int id = Convert.ToInt32(Request["CartID"]);
                Response<CartDisplayModel> cart = customerController.GetOneCartDisplayModel(userID, id);

                lblStationeryName.Text = cart.PassValue.StationeryName;
                lblStationeryPrice.Text = cart.PassValue.StationeryPrice.ToString();
                txtQuantity.Text = cart.PassValue.Quantity.ToString();
            }
        }

        protected void btnUpdateCart_click(object sender, EventArgs e)
        {
            int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
            int id = Convert.ToInt32(Request["CartID"]);
            int quantity = Convert.ToInt32(txtQuantity.Text);

            Response<Cart> response = customerController.UpdateCart(userID, id, quantity);

            if (response.IsSuccess)
            {
                lblMessage.Text = "Cart Updated Successfully";
            }
        }
    }
}