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
    public partial class CustomerTransactionDetail : System.Web.UI.Page
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
            int id = Convert.ToInt32(Request["ID"]);
            Response<List<TransactionDetail>> response = customerHandler.ViewTransactionDetailByTransactionID(id);
            detailGrid.DataSource = response.PassValue;

            if (response.PassValue != null)
            {
                detailGrid.DataBind();
            }
            else
            {
              
            }
        }

    }
}