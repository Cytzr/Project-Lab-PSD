using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public class StationeryRepository
    {
        Database1Entities1 _context = DatabaseSingleton.getInstance();
        public List<MsStationery> GetAllStationery()
        {
            return _context.MsStationeries.ToList();
        }

        public MsStationery GetStationeryByID(int stationeryID)
        {
            return (from a in _context.MsStationeries
                    where a.StationeryID == stationeryID
                    select a).FirstOrDefault();
        }

        public void AddStationery(MsStationery stationery)
        {
            _context.MsStationeries.Add(stationery);
            _context.SaveChangesAsync();
        }

        public MsStationery UpdateStationery(MsStationery stationery)
        {
            MsStationery temp = (from a in _context.MsStationeries
                                 where a.StationeryID == stationery.StationeryID
                                 select a).FirstOrDefault();
            temp.StationeryPrice = stationery.StationeryPrice;
            temp.StationeryName = stationery.StationeryName;
            _context.SaveChanges();
            return temp;
        }

        public MsStationery DeleteStationery(int stationeryID)
        {
            MsStationery temp = (from a in _context.MsStationeries
                                 where a.StationeryID == stationeryID
                                 select a).FirstOrDefault();
            if (temp != null)_context.MsStationeries.Remove(temp);
            _context.SaveChanges();
            return temp;
        }
    }
}