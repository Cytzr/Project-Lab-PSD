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

namespace Project_Lab_PSD.Views.Guest
{
    public partial class GuestStationeryPage : System.Web.UI.Page
    {
        CustomerHandler customerHandler = new CustomerHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStationeryData();
            }
        }
        protected void BindStationeryData()
        {
            Response<List<MsStationery>> response = customerHandler.ViewStationeries();
            stationeryGrid.DataSource = response.PassValue;

            if (response != null)
            {
                stationeryGrid.DataBind();
            }
            else
            {
                Console.WriteLine("No Data");
            }
        }
        protected void stationeryGrid_RowCommand(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = stationeryGrid.Rows[e.NewSelectedIndex];

            string name = row.Cells[0].Text.ToString();
            Response<MsStationery> response = customerHandler.GetStationaryByName(name);
            string id = response.PassValue.StationeryID.ToString();

            Response.Redirect("~/Views/Guest/GuestStationaryDetail.aspx?ID=" + id);
        }
    }
}