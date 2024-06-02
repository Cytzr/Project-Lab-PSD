using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Models
{
    public class TransactionReportModel
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StationeryID { get; set; }
        public string StationeryName { get; set; }
        public int StationeryPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice {  get; set; }
    }
}