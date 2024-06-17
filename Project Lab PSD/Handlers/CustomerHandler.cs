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
    public class CustomerHandler
    {
        StationeryRepository stationeryRepo = new StationeryRepository();
        CartRepository cartRepo = new CartRepository();
        UserRepository userRepo = new UserRepository();
        TransactionHeaderRepository transactionHeaderRepo = new TransactionHeaderRepository();
        TransactionDetailRepository transactionDetailRepo = new TransactionDetailRepository();
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

        public Response<MsStationery> GetStationeryById(int stationeryId)
        {
            MsStationery temp = stationeryRepo.GetStationeryByID(stationeryId);

            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "All Stationery Sent",
                PassValue = temp,
            };
        }

        public Response<MsStationery> GetStationaryByName(string stationeryName)
        {
            MsStationery temp = stationeryRepo.GetStationeryByName(stationeryName);

            return new Response<MsStationery>()
            {
                IsSuccess = true,
                Message = "Stationery Name Sent",
                PassValue = temp,
            };
        }

        public Response<Cart> AddCart (int userID, int stationeryID, int quantity)
        {
            Cart cart = CartFactory.create_cart(userID, stationeryID, quantity);
            cartRepo.InsertCart(cart);
            return new Response<Cart>()
            {
                IsSuccess = true,
                Message = "Cart Inserted",
                PassValue = cart,
            };
        }

        public Response<CartDisplayModel> GetOneCartDisplayModel(int userID, int stationeryID)
        {
            var temp = cartRepo.GetCartByBothCredential(userID, stationeryID);
            if(temp == null)
            {
                return new Response<CartDisplayModel>()
                {
                    IsSuccess = true,
                    Message = "Stationery Displayed",
                    PassValue = temp,
                };
            }
            else
            {
                return new Response<CartDisplayModel>()
                {
                    IsSuccess = false,
                    Message = "No Detail Found",
                    PassValue = temp,
                };
            }
        }

        public Response<List<Cart>> OrderStationeries(int userID)
        {
            List<CartDisplayModel> tempCart = cartRepo.GetCartByUserID(userID);

            foreach (CartDisplayModel cart in tempCart)
            {
                TransactionHeader th = new TransactionHeader()
                {
                    UserID = cart.UserID,
                    TransactionDate = DateTime.Now,
                };

                transactionHeaderRepo.AddTransactionHeader(th);

                int tdID = transactionHeaderRepo.GetLastTransactionHeaderID();

                TransactionDetail td = TransactionDetailFactory.create_transaction_detail(tdID,cart.StationeryID,cart.Quantity);

                transactionDetailRepo.AddTransactionDetail(td);
            }

            List<Cart> deletedCart = cartRepo.DeleteCartByUserID(userID);

            if (deletedCart != null)
            {
                return new Response<List<Cart>>()
                {
                    IsSuccess = true,
                    Message = "Order Finished",
                    PassValue = deletedCart,
                };
            }
            return new Response<List<Cart>>()
            {
                IsSuccess = false,
                Message = "Something went wrong",
                PassValue = null,
            };
        }

        public Response<List<CartDisplayModel>> ViewCarts(int userID)
        {
            List<CartDisplayModel> temp = cartRepo.GetCartByUserID(userID);

            return new Response<List<CartDisplayModel>>()
            {
                IsSuccess = true,
                Message = "All User Cart Sent",
                PassValue = temp,
            };
        }

        public Response<List<CartDisplayModel>> GetCartByStationeryID(int stationeryID)
        {
            List<CartDisplayModel> temp = cartRepo.GetCartByStationeryID(stationeryID);

            return new Response<List<CartDisplayModel>>()
            {
                IsSuccess = true,
                Message = "Sent",
                PassValue = temp,
            };
        }

        public Response<Cart> UpdateCart(int userID, int stationeryID, int quantity)
        {
            Cart cart = CartFactory.create_cart(userID, stationeryID, quantity);
            Cart temp = cartRepo.UpdateCart(cart);

            if (temp != null)
            {
                return new Response<Cart>()
                {
                    IsSuccess = true,
                    Message = "Cart Updated",
                    PassValue = temp,
                };
            }
            return new Response<Cart>()
            {
                IsSuccess = false,
                Message = "Something went wrong",
                PassValue = null,
            };
        }

        public Response<Cart> DeleteCart(int userID, int stationeryID)
        {
            Cart temp = cartRepo.DeleteCartByBothCredential(userID, stationeryID);

            if (temp != null)
            {
                return new Response<Cart>()
                {
                    IsSuccess = true,
                    Message = "Cart Deleted",
                    PassValue = temp,
                };
            }
            return new Response<Cart>()
            {
                IsSuccess = false,
                Message = "Something went wrong",
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

        public Response<List<TransactionReportModel>> ViewTransactionHistory(int userID)
        {
            List<TransactionReportModel> temp = transactionReportRepo.GetAllTransactionReportByUserID(userID);

            if (temp != null)
            {
                return new Response<List<TransactionReportModel>>()
                {
                    IsSuccess = true,
                    Message = "All Transaction History Sent",
                    PassValue = temp,
                };
            }
            return new Response<List<TransactionReportModel>>()
            {
                IsSuccess = false,
                Message = "No Transaction History Found",
                PassValue = null,
            };
        }


        public Response<List<TransactionDetail>> ViewTransactionDetailByTransactionID(int transactionID)
        {
            List<TransactionDetail> temp = transactionDetailRepo.GetTransactionDetailByTransactionID(transactionID);

            if (temp != null)
            {
                return new Response<List<TransactionDetail>>()
                {
                    IsSuccess = true,
                    Message = "All Transaction Detail Sent",
                    PassValue = temp,
                };
            }
            return new Response<List<TransactionDetail>>()
            {
                IsSuccess = false,
                Message = "No Transaction Detail Found",
                PassValue = null,
            };
        }

        public Response<List<TransactionDetail>> ViewTransactionDetailByUserID(int userID)
        {
            List<TransactionDetail> temp = transactionDetailRepo.GetTransactionDetailByUserID(userID);

            if (temp != null)
            {
                return new Response<List<TransactionDetail>>()
                {
                    IsSuccess = true,
                    Message = "All Transaction Detail Sent",
                    PassValue = temp,
                };
            }
            return new Response<List<TransactionDetail>>()
            {
                IsSuccess = false,
                Message = "No Transaction Detail Found",
                PassValue = null,
            };
        }
    }
}