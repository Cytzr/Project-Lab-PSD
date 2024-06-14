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

        public Response<MsStationery> UpdateStationery(string stationeryName, int stationeryPrice)
        {
            MsStationery stationery = MsStationeryFactory.create_stationery(stationeryName, stationeryPrice);
            MsStationery updatedStationery = stationeryRepo.UpdateStationery(stationery);

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

        public Response<MsUser> UpdateProfileByID(MsUser user)
        {
            MsUser updatedUser = userRepo.UpdateUserByID(user);
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
    }
}