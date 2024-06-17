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
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            string idString = Request.QueryString["StationeryID"];
            int id;
            int.TryParse(idString, out id);
            string productName = newNameVal.Text.Trim();
            string strProductPrice = newPriceVal.Text.Trim();

            int productPrice = int.Parse(strProductPrice);

            Response<MsStationery> response = adminController.updateProduct(id, productName, productPrice);

            if (response.IsSuccess)
            {
                Msg.Text = "Product updated";
            }
            else
            {
                Msg.Text = "Product update failed   ";
            }
        }
    }
}