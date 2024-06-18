using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Controllers
{
    public class AdminController
    {
        AdminHandler adminHandler = new AdminHandler();
        StationeryRepository stationeryRepository = new StationeryRepository();
        public Response<MsStationery> insertProduct(string productName, int productPrice)
        {
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

        public Response<MsStationery> updateProduct(int stationeryId, string productName, int productPrice)
        {
            Response<MsStationery> response = adminHandler.UpdateStationery(stationeryId, productName, productPrice);

            if (response.IsSuccess)
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = true,
                    Message = "Stationery updated",
                    PassValue = response.PassValue,
                };
            }
            else
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = false,
                    Message = "Failed to update",
                    PassValue = null,
                };
            }
        }
        public Response<MsStationery> GetDataStationeryByID(int id)
        {
            MsStationery response = adminHandler.ViewStationeryById(id).PassValue;
            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "All Stationery Sent",
                PassValue = response,
            };
        }

        public Response<List<TransactionHeader>> GetDataTransactionHeader()
        {
            List<TransactionHeader> response = adminHandler.ViewTransactionHeader().PassValue;
            return new Response<List<TransactionHeader>>()
            {
                IsSuccess = true,
                Message = "All Stationery Sent",
                PassValue = response,
            };
        }

        public bool findTransactionDetailByStationeryID (int id)
        {
            List<TransactionDetail> response = adminHandler.ViewTransactionDetail().PassValue;

            foreach(TransactionDetail res in response)
            {
                if(res.StationeryID == id)
                {
                    return true;
                }
            }

            return false;
        }
        public int TotalValue(int transactionID)
        {
            List<TransactionDetail> response = adminHandler.ViewTransactionDetail().PassValue;
            int allTotal = 0;

            foreach (TransactionDetail detail in response)
            {
                if (detail.TransactionID == transactionID)
                {
                    MsStationery item = adminHandler.ViewStationeryById(detail.StationeryID).PassValue;
                    int subtotal = item.StationeryPrice * detail.Quantity;
                    allTotal += subtotal;
                }

            }

            return allTotal;
        }

        public int SubValue(int stationeryID)
        {
            List<TransactionDetail> response = adminHandler.ViewTransactionDetail().PassValue;
            int total = 0;
            foreach (TransactionDetail detail in response)
            {
                if (detail.StationeryID == stationeryID)
                {
                    MsStationery item = adminHandler.ViewStationeryById(detail.StationeryID).PassValue;
                    total = item.StationeryPrice * detail.Quantity;
                    break;
                }
            }
            return total;
        }
    }
}