using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Factories
{
    public class TransactionReportModelFactory
    {
        public TransactionReportModel create_new_transaction_report(int transactionID, int userID, string userName, DateTime transactionDate, int stationeryID, string stationeryName, int stationeryPrice, int quantity, int totalPrice)
        {
            TransactionReportModel temp = new TransactionReportModel()
            {
                TransactionID = transactionID,
                UserID = userID,
                UserName = userName,
                TransactionDate = transactionDate,
                StationeryID = stationeryID,
                StationeryName = stationeryName,
                StationeryPrice = stationeryPrice,
                Quantity = quantity,
                TotalPrice = totalPrice,
            };

            return temp;
        }
    }
}