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
    public partial class CustomerTransactionHistoryPage : System.Web.UI.Page
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
            int userID = int.Parse(Request.Cookies["user_cookie"]?.Value);
            Response<List<TransactionReportModel>> response = customerHandler.ViewTransactionHistory(userID);
            historyGrid.DataSource = response.PassValue;
            
            if (response.PassValue != null)
            {
                historyGrid.DataBind();
            }
            else
            {
                Response.Write($"<script>alert('{userID}');</script>");
            }
        }
        protected void stationeryGrid_RowCommand(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = historyGrid.Rows[e.NewSelectedIndex];

            string name = row.Cells[0].Text.ToString();
            Response<MsStationery> response = customerHandler.GetStationaryByName(name);
            string id = response.PassValue.StationeryID.ToString();

            Response.Redirect("~/Views/Customer/CustomerDetailStationer.aspx?ID=" + id);
        }
    }
}