using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Controllers
{
    public class AdminController
    {
        private AdminHandler adminHandler;
        public Response<MsStationery> insertProduct(string productName, int productPrice)
        {
            adminHandler = new AdminHandler(); 
            Response<MsStationery> response = adminHandler.InsertStationery(productName, productPrice);

            if (response.IsSuccess)
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = true,
                    Message = "Stationery Added",
                    PassValue = response.PassValue, 
                };
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = "Failed to add stationery",
                    PassValue = null,
                };
            }
        }
    }
}