using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Lab_PSD.Controllers;
using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;

namespace Project_Lab_PSD.Views.Admin
{
    public partial class AdminStationeryPage : System.Web.UI.Page
    {
        private AdminHandler adminHandler;
        protected void Page_Load(object sender, EventArgs e)
        {
            adminHandler = new AdminHandler();

            Response<List<MsStationery>> response = adminHandler.ViewStationeries();
            GridView1.DataSource = response.PassValue;

            if (response != null)
            {
                GridView1.DataBind();
            }
            else
            {
                Console.WriteLine("No data");
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string stringId = row.Cells[0].Text.ToString();

            int id = 0;

            int.TryParse(stringId, out id);

            Response<MsStationery> deleteResponse = adminHandler.DeleteStationery(id);

            Response.Redirect("AdminStationeryPage.aspx");
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertStationery.aspx");
        }
    }   
}