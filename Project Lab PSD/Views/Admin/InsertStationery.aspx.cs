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

            if(string.IsNullOrWhiteSpace(nameVal.Text.Trim()) && string.IsNullOrWhiteSpace(priceVal.Text.Trim()))
            {
                Msg.Text = "Please input the data";
                return;
            }

            string productName = nameVal.Text.Trim();
            string strProductPrice = priceVal.Text.Trim();


            int productPrice = int.Parse(strProductPrice);
            
            bool res = validate(productName, productPrice);

            if(res == true)
            {
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

        protected bool validate(string productName, int price)
        {
            if (string.IsNullOrWhiteSpace(productName) || productName.Length < 3 || productName.Length > 50)
            {
                Msg.Text = "Name must be filled and between 3 to 50 characters.";
                return false;
            }

            if (price < 2000)
            {
                Msg.Text = "Price must be filled, numeric, and greater or equal to 2000.";
                return false;
            }
            return true;
        }
    }
}