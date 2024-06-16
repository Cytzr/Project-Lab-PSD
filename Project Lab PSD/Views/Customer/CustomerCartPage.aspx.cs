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
                int userID = 2;
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
    }
}