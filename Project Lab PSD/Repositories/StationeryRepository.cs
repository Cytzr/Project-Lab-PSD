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
            try
            {
                return _context.MsStationeries.ToList();
            }
            catch
            {
                return null;
            }
        }

        public MsStationery GetStationeryByID(int stationeryID)
        {
            try
            {
                return (from a in _context.MsStationeries
                        where a.StationeryID == stationeryID
                        select a).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public MsStationery GetStationeryByName(string stationeryName)
        {
            return (from a in _context.MsStationeries
                    where a.StationeryName == stationeryName
                    select a).FirstOrDefault();
        }

        public void AddStationery(MsStationery stationery)
        {
            try
            {
                _context.MsStationeries.Add(stationery);
                _context.SaveChangesAsync();
            }   
            catch
            {
                throw new Exception();
            }
        }

        public MsStationery UpdateStationery(int id, MsStationery stationery)
        {
            MsStationery temp = (from a in _context.MsStationeries
                                 where a.StationeryID == id
                                 select a).FirstOrDefault();
            temp.StationeryPrice = stationery.StationeryPrice;
            temp.StationeryName = stationery.StationeryName;
            _context.SaveChanges();
            return temp;
        }

        public MsStationery DeleteStationery(int stationeryID)
        {
            try
            {
                MsStationery temp = (from a in _context.MsStationeries
                                     where a.StationeryID == stationeryID
                                     select a).FirstOrDefault();
                if (temp != null) _context.MsStationeries.Remove(temp);
                _context.SaveChanges();
                return temp;
            }
            catch
            {
                return null;
            }
        }
    }
}