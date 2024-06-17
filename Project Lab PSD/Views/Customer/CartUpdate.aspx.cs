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
        CustomerHandler customerHandler = new CustomerHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = 2;
                int id = Convert.ToInt32(Request["ID"]);
                Response<CartDisplayModel> response = customerHandler.GetOneCartDisplayModel(userID, id);
                CartDisplayModel user2 = response.PassValue;

                lblStationeryName.Text = user2.StationeryName;
                lblStationeryPrice.Text = user2.StationeryPrice.ToString();
                txtQuantity.Text = user2.Quantity.ToString();
            }
        }

        protected void btnUpdateCart_click(object sender, EventArgs e)
        {
            int userID = 2;
            int id = Convert.ToInt32(Request["ID"]);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            Response<Cart> response = customerHandler.UpdateCart(userID, id, quantity);
        }
    }
}