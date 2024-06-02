using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Factories
{
    public class MsStationeryFactory
    {
        public static MsStationery create_stationery(string stationeryName, int stationeryPrice)
        {
            MsStationery msStationery = new MsStationery()
            {
                StationeryName = stationeryName,
                StationeryPrice = stationeryPrice
            };

            return msStationery;
        }
    }
}