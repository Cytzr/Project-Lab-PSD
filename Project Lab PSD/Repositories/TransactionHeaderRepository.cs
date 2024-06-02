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
            return _context.TransactionHeaders.ToList();
        }

        public int GetLastTransactionHeaderID()
        {
            return _context.TransactionHeaders.LastOrDefault().TransactionID;
        }

        public TransactionHeader GetTransactionHeaderByID(int transactionHeaderID)
        {
            return (from a in _context.TransactionHeaders
                    where a.TransactionID == transactionHeaderID
                    select a).FirstOrDefault();
        }
        
        public List<TransactionHeader> GetTransactionHeaderByUserID(int userID)
        {
            return (from a in _context.TransactionHeaders
                    where a.UserID == userID
                    select a).ToList();
        }

        public void AddTransactionHeader(TransactionHeader transactionHeader)
        {
            _context.TransactionHeaders.Add(transactionHeader);
            _context.SaveChanges();
        }

        public TransactionHeader DeleteTransactionHeader(int id)
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
    }
}