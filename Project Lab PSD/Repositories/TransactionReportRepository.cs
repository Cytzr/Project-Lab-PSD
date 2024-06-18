using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public class TransactionReportRepository
    {
        Database1Entities1 _context = DatabaseSingleton.getInstance();

        public List<TransactionReportModel> GetAllTransactionReport()
        {
            try
            {
                List<TransactionReportModel> list = (from a in _context.TransactionHeaders
                                                     join b in _context.MsUsers
                                                     on a.UserID equals b.UserID
                                                     join c in _context.TransactionDetails
                                                     on a.TransactionID equals c.TransactionID
                                                     join d in _context.MsStationeries
                                                     on c.StationeryID equals d.StationeryID
                                                     select new TransactionReportModel()
                                                     {
                                                         TransactionID = a.TransactionID,
                                                         UserID = a.UserID,
                                                         UserName = b.UserName,
                                                         TransactionDate = a.TransactionDate,
                                                         StationeryID = c.StationeryID,
                                                         StationeryName = d.StationeryName,
                                                         StationeryPrice = d.StationeryPrice,
                                                         Quantity = c.Quantity,
                                                         TotalPrice = c.Quantity * d.StationeryPrice,
                                                     }).ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<TransactionReportModel> GetAllTransactionReportByUserID(int userID)
        {
            try
            {
                List<TransactionReportModel> list = (from a in _context.TransactionHeaders
                                                     join b in _context.MsUsers
                                                     on a.UserID equals b.UserID
                                                  
                                                     where a.UserID == userID
                                                     select new TransactionReportModel()
                                                     {
                                                         TransactionID = a.TransactionID,
                                                         UserID = a.UserID,
                                                         UserName = b.UserName,
                                                         TransactionDate = a.TransactionDate,
                                                     }).ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}