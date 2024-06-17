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
    public partial class CustomerUpdateStationery : System.Web.UI.Page
    {
        CustomerHandler customerHandler = new CustomerHandler();
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
            

            if ( != null)
            {
                
            }
        }
    }
}