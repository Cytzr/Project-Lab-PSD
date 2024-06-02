using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader create_transaction_header(int userID, DateTime transactionDate)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                UserID = userID,
                TransactionDate = transactionDate,
            };

            return transactionHeader;
        }
    }
}