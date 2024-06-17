using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public class TransactionHeaderRepository
    {
        Database1Entities1 _context = DatabaseSingleton.getInstance();

        public List<TransactionHeader> GetAllTransactionHeader()
        {
            try
            {
                return _context.TransactionHeaders.ToList();
            }
            catch
            {
                return null;
            }
        }

        public int GetLastTransactionHeaderID()
        {
            try
            {
                return (from a in _context.TransactionHeaders
                        orderby a.TransactionID descending
                        select a.TransactionID).FirstOrDefault();
            }
            catch
            {
                return 0;
            }
        }

        public TransactionHeader GetTransactionHeaderByID(int transactionHeaderID)
        {
            try
            {
                return (from a in _context.TransactionHeaders
                        where a.TransactionID == transactionHeaderID
                        select a).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionHeader> GetTransactionHeaderByUserID(int userID)
        {
            try
            {
                return (from a in _context.TransactionHeaders
                        where a.UserID == userID
                        select a).ToList();
            }
            catch
            {
                return null;
            }
        }

        public void AddTransactionHeader(TransactionHeader transactionHeader)
        {
            try
            {
                _context.TransactionHeaders.Add(transactionHeader);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public TransactionHeader DeleteTransactionHeader(int id)
        {
            try
            {
                TransactionDetail tempDetail = (from a in _context.TransactionDetails
                                                where a.TransactionID == id
                                                select a).FirstOrDefault();
                _context.TransactionDetails.Remove(tempDetail);

                TransactionHeader tempHeader = (from a in _context.TransactionHeaders
                                                where a.TransactionID == id
                                                select a).FirstOrDefault();
                _context.TransactionHeaders.Remove(tempHeader);

                _context.SaveChanges();
                return tempHeader;
            }
            catch
            {
                return null;
            }
        }
    }
}