using Project_Lab_PSD.Controllers;
using Project_Lab_PSD.CrystalReport;
using Project_Lab_PSD.Dataset;
using Project_Lab_PSD.Handlers;
using Project_Lab_PSD.Models;
using Project_Lab_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab_PSD.Views.Admin
{
    public partial class AdminTransactionReportPage : System.Web.UI.Page
    {
        AdminController adminController = new AdminController();
        AdminHandler adminHandler = new AdminHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            adminHandler = new AdminHandler();    
            CrystalReport1 response = new CrystalReport1();
            CrystalReportViewer1.ReportSource = response;

            DataSet1 value = crystalReportData(adminHandler.ViewTransactionHeader().PassValue);
            response.SetDataSource(value);
        }

        protected DataSet1 crystalReportData(List<TransactionHeader> transactionHeaders)
        {
            DataSet1 data = new DataSet1();
            var dataDetail = data.TransactionDetail;
            var dataHeader = data.TransactionHeader;

            foreach (TransactionHeader transactionHeader in transactionHeaders)
            {
                var header = dataHeader.NewRow();
                header["TransactionID"] = transactionHeader.TransactionID;
                header["UserID"] = transactionHeader.UserID;
                header["TransactionDate"] = transactionHeader.TransactionDate;
                header["GrandTotalValue"] = adminController.TotalValue(transactionHeader.TransactionID);
                dataHeader.Rows.Add(header);

                foreach(TransactionDetail transactionDetail in transactionHeader.TransactionDetails)
                {
                    var detail = dataDetail.NewRow();
                    MsStationery response = adminController.GetDataStationeryByID(transactionDetail.StationeryID).PassValue;

                    detail["TransactionID"] = transactionDetail.TransactionID;
                    detail["StationeryID"] = response.StationeryID;
                    detail["StationeryName"] = response.StationeryName;
                    detail["StationeryPrice"] = response.StationeryPrice;
                    detail["Quantity"] = transactionDetail.Quantity;
                    detail["SubTotalValue"] = adminController.SubValue(response.StationeryID);

                    dataDetail.Rows.Add(detail);
                }
            }
            return data;
        }
    }
}