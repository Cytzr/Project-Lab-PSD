﻿using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Guest
{
    public partial class GuestStationaryDetail : System.Web.UI.Page
    {
        CustomerHandler customerHandler = new CustomerHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["ID"]);
                Response<MsStationery> response = customerHandler.GetStationeryById(id);
                MsStationery user2 = response.PassValue;

                lblStationeryName.Text = user2.StationeryName;
                lblStationeryPrice.Text = user2.StationeryPrice.ToString();
            }
        }
      
    }
}