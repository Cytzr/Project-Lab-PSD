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
        CustomerController customerCont = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
                int id = Convert.ToInt32(Request["ID"]);
                Response<CartDisplayModel> response = customerCont.GetOneCartDisplayModel(userID, id);
                CartDisplayModel user2 = response.PassValue;

                lblStationeryName.Text = user2.StationeryName;
                lblStationeryPrice.Text = user2.StationeryPrice.ToString();
                txtQuantity.Text = user2.Quantity.ToString();
            }
        }

        protected void btnUpdateCart_click(object sender, EventArgs e)
        {
            int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
            int id = Convert.ToInt32(Request["ID"]);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            Response<Cart> response = customerCont.UpdateCart(userID, id, quantity);
        }
    }
}