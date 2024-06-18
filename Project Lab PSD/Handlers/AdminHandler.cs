using Project_Lab_PSD.Factories;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
using Project_Lab_PSD.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Handlers
{
    public class AdminHandler
    {
        StationeryRepository stationeryRepo = new StationeryRepository();
        UserRepository userRepo = new UserRepository();
        TransactionReportRepository transactionReportRepo = new TransactionReportRepository();
        TransactionHeaderRepository transactionHeaderRepo = new TransactionHeaderRepository();
        TransactionDetailRepository transactionDetailRepo = new TransactionDetailRepository();
        public Response<List<MsStationery>> ViewStationeries()
        {
            List<MsStationery> temp = stationeryRepo.GetAllStationery();
            return new Response<List<MsStationery>>()
            {
                IsSuccess = true,
                Message = "All Stationery Sent",
                PassValue = temp,
            };
        }

        public Response<MsStationery> ViewStationeryById(int id) 
        {
            MsStationery response = stationeryRepo.GetStationeryByID(id);
            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "All Stationery Sent",
                PassValue = response,
            };
        }

        public Response<MsStationery> InsertStationery(string stationeryName, int stationeryPrice)
        {
            MsStationery stationery = MsStationeryFactory.create_stationery(stationeryName, stationeryPrice);
            stationeryRepo.AddStationery(stationery);

            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "Stationery Added",
                PassValue = null,
            };
        }

        public Response<MsStationery> UpdateStationery(int stationeryId, string stationeryName, int stationeryPrice)
        {
            MsStationery stationery = MsStationeryFactory.create_stationery(stationeryName, stationeryPrice);
            MsStationery updatedStationery = stationeryRepo.UpdateStationery(stationeryId, stationery);

            if(updatedStationery != null)
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = true,
                    Message = "Stationery Updated",
                    PassValue = updatedStationery,
                };
            }
            return new Response<MsStationery>()
            {
                IsSuccess = false,
                Message = "Stationery Not Found",
                PassValue = null,
            };
        }

        public Response<MsStationery> DeleteStationery(int stationeryID)
        {
            MsStationery deletedStationery = stationeryRepo.DeleteStationery(stationeryID);

            if (deletedStationery != null)
            {
                return new Response<MsStationery>()
                {
                    IsSuccess = true,
                    Message = "Stationery Deleted",
                    PassValue = deletedStationery,
                };
            }
            return new Response<MsStationery>()
            {
                IsSuccess = false,
                Message = "Stationery Not Found",
                PassValue = null,
            };
        }

        public Response<MsUser> UpdateProfileByID(int id, MsUser user)
        {
            MsUser updatedUser = userRepo.UpdateUserByID(id, user);
            if (updatedUser != null)
            {
                return new Response<MsUser>()
                {
                    IsSuccess = true,
                    Message = "User Updated",
                    PassValue = updatedUser,
                };
            }
            return new Response<MsUser>()
            {
                IsSuccess = false,
                Message = "User Not Found",
                PassValue = null,
            };
        }

        public Response<MsUser> UpdateProfileByName(MsUser user)
        {
            MsUser updatedUser = userRepo.UpdateUserByUserName(user);
            if (updatedUser != null)
            {
                return new Response<MsUser>()
                {
                    IsSuccess = true,
                    Message = "User Updated",
                    PassValue = updatedUser,
                };
            }
            return new Response<MsUser>()
            {
                IsSuccess = false,
                Message = "User Not Found",
                PassValue = null,
            };
        }

        public Response<List<TransactionReportModel>> ViewTransactionReport()
        {
            List<TransactionReportModel> temp = transactionReportRepo.GetAllTransactionReport();

            if (temp != null)
            {
                return new Response<List<TransactionReportModel>>()
                {
                    IsSuccess = true,
                    Message = "All Transaction Report Sent",
                    PassValue = temp,
                };
            }
            return new Response<List<TransactionReportModel>>()
            {
                IsSuccess = false,
                Message = "No Transaction Report Found",
                PassValue = null,
            };
        }
        public Response<List<TransactionHeader>> ViewTransactionHeader()
        {
            List<TransactionHeader> response = transactionHeaderRepo.GetAllTransactionHeader();
            return new Response<List<TransactionHeader>>()
            {
                IsSuccess = true,
                Message = "All Transaction Report Sent",
                PassValue = response,
            };
        }

        public Response<List<TransactionDetail>> ViewTransactionDetail()
        {
            List<TransactionDetail> response = transactionDetailRepo.GetAllTransactionDetail();
            return new Response<List<TransactionDetail>>()
            {
                IsSuccess = true,
                Message = "All Transaction Report Sent",
                PassValue = response,
            };
        }

        public Response<List<TransactionDetail>> ViewTransactionDetailByTransactionID(int transactionID)
        {
            List<TransactionDetail> response = transactionDetailRepo.GetTransactionDetailByTransactionID(transactionID);
            return new Response<List<TransactionDetail>>()
            {
                IsSuccess = true,
                Message = "All Transaction Report Sent",
                PassValue = response,
            };
        }
    }
}