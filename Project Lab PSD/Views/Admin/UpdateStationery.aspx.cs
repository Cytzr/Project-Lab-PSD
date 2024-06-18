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

namespace Project_Lab_PSD.Views.Admin
{
    public partial class UpdateStationery : System.Web.UI.Page
    {
        AdminController adminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idString = Request.QueryString["StationeryID"];
                int id;
                int.TryParse(idString, out id);

                load(id);
            }
        }

        public void load(int id)
        {
            MsStationery response = adminController.GetDataStationeryByID(id).PassValue;

            if (response != null)
            {
                oldNameVal.Text = response.StationeryName;
                oldPriceVal.Text = response.StationeryPrice.ToString();
            }
            else
            {
                Response.Write("<script>alert('Stationery not found');</script>");
                Response.Redirect("AdminStationeryPage.aspx");
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            string idString = Request.QueryString["StationeryID"];
            int id;
            int.TryParse(idString, out id);
            string productName = newNameVal.Text.Trim();
            string strProductPrice = newPriceVal.Text.Trim();

            if(string.IsNullOrWhiteSpace(newNameVal.Text.Trim()) && string.IsNullOrWhiteSpace(newPriceVal.Text.Trim()))
            {
                Msg.Text = "Please input the data";
                return;
            }

            int productPrice = int.Parse(strProductPrice);

            bool res = validate(productName, productPrice);

            Response<MsStationery> response = adminController.updateProduct(id, productName, productPrice);

            if (response.IsSuccess)
            {
                Msg.Text = "Product updated";
            }
            else
            {
                Msg.Text = "Product update failed";
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