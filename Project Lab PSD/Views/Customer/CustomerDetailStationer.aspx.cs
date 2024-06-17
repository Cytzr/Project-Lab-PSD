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
    public partial class CustomerDetailStationer : System.Web.UI.Page
    {
        CustomerController customerCont = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                Response<MsStationery> response = customerCont.GetStationeryById(id);
                MsStationery user2 = response.PassValue;

                lblStationeryName.Text = user2.StationeryName;
                lblStationeryPrice.Text = user2.StationeryPrice.ToString();
            }
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int userID = 2;
            int id = Convert.ToInt32(Request["ID"]);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            Response<Cart> response = customerCont.AddCart(userID, id, quantity);

            if (response.IsSuccess)
            {
                lblMessage.Text = "Stationary Added to Cart";
            }
        }
    }
}