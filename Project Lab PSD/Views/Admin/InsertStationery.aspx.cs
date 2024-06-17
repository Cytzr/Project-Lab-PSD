using Project_Lab_PSD.Controllers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Admin
{
    public partial class InsertStationery : System.Web.UI.Page
    {
        private AdminController adminController;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert_Click(object sender, EventArgs e)
        {
            adminController = new AdminController();
            string productName = nameVal.Text.Trim();
            string strProductPrice = priceVal.Text.Trim();


            int productPrice = int.Parse(strProductPrice);

            Response<MsStationery> response = adminController.insertProduct(productName, productPrice);

            if (response.IsSuccess)
            {
                Msg.Text = "Product added successfully.";
            }
            else
            {
                Msg.Text = "Product added failed.";
            }
        }
    }
}