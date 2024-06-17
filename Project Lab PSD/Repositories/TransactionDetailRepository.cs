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
            try
            {
                return _context.TransactionDetails.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionDetail> GetTransactionDetailByTransactionID(int transactionID)
        {
            try
            {
                return (from a in _context.TransactionDetails
                        where a.TransactionID == transactionID
                        select a).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionDetail> GetTransactionDetailByUserID(int userID)
        {
            try
            {
                return (from a in _context.TransactionDetails
                        join b in _context.TransactionHeaders
                        on a.TransactionID equals b.TransactionID
                        where b.UserID == userID
                        select a).ToList();
            }
            catch
            {
                return null;
            }
        }

        public void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            try
            {
                _context.TransactionDetails.Add(transactionDetail);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
            
                throw ex;
            }
        }
    }
}