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
    public class GuestHandler
    {
        StationeryRepository stationeryRepo = new StationeryRepository();
        UserRepository userRepo = new UserRepository();

        public Response<MsUser> Login(string userName, string password)
        {
            MsUser temp = userRepo.Login(userName, password);

            if(temp != null)
            {
                return new Response<MsUser>()
                {
                    IsSuccess = true,
                    Message = "User Logged In",
                    PassValue = temp,
                };
            }
            return new Response<MsUser>()
            {
                IsSuccess = false,
                Message = "Invalid Credentials",
                PassValue = null,
            };
        }

        public Response<MsUser> Register(string userName, string userGender, DateTime userDOB, string userPhone, string userAddress, string userPassword, string userRole)
        {
            MsUser temp = MsUserFactory.create_user(userName, userGender, userDOB, userPhone, userAddress, userPassword, userRole);

            return new Response<MsUser>()
            {
                IsSuccess = true,
                Message = "User Registered",
                PassValue = temp,
            };
        }

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
    }
}