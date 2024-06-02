using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail create_transaction_detail(int  transactionID, int stationeryID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionID,
                StationeryID = stationeryID,
                Quantity = quantity,
            };

            return transactionDetail;
        }
    }
}