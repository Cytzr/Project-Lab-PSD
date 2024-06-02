using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public class TransactionDetailRepository
    {
        Database1Entities1 _context = DatabaseSingleton.getInstance();

        public List<TransactionDetail> GetAllTransactionDetail()
        {
            return _context.TransactionDetails.ToList();
        }

        public List<TransactionDetail> GetTransactionDetailByTransactionID(int transactionID)
        {
            return (from a in _context.TransactionDetails
                    where a.TransactionID == transactionID
                    select a).ToList();
        }

        public List<TransactionDetail> GetTransactionDetailByUserID(int userID)
        {
            return (from a in _context.TransactionDetails
                    join b in _context.TransactionHeaders
                    on a.TransactionID equals b.TransactionID
                    where b.UserID == userID
                    select a).ToList();
        }

        public void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            _context.TransactionDetails.Add(transactionDetail);
            _context.SaveChanges();
        }
    }
}