﻿using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public class CartRepository
    {
        Database1Entities1 _context = DatabaseSingleton.getInstance();

        public List<CartDisplayModel> GetCartByUserID(int userID)
        {
            try
            {
                var temp = (from a in _context.Carts
                            join b in _context.MsUsers
                            on a.UserID equals b.UserID
                            join c in _context.MsStationeries
                            on a.StationeryID equals c.StationeryID
                            where a.UserID == userID
                            select new CartDisplayModel()
                            {
                                UserID = a.UserID,
                                UserName = b.UserName,
                                StationeryID = a.StationeryID,
                                StationeryName = c.StationeryName,
                                StationeryPrice = c.StationeryPrice,
                                Quantity = a.Quantity,
                                TotalPrice = a.Quantity * c.StationeryPrice,
                            }).ToList();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public List<CartDisplayModel> GetCartByStationeryID(int stationeryID)
        {
            try
            {
                var temp = (from a in _context.Carts
                            join b in _context.MsUsers
                            on a.UserID equals b.UserID
                            join c in _context.MsStationeries
                            on a.StationeryID equals c.StationeryID
                            where a.StationeryID == stationeryID
                            select new CartDisplayModel()
                            {
                                UserID = a.UserID,
                                StationeryID = a.StationeryID,
                                UserName = b.UserName,
                                StationeryName = c.StationeryName,
                                StationeryPrice = c.StationeryPrice,
                                Quantity = a.Quantity,
                                TotalPrice = a.Quantity * c.StationeryPrice,
                            }).ToList();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public CartDisplayModel GetCartByBothCredential(int userID, int stationeryID)
        {
            try
            {
                var temp = (from a in _context.Carts
                            join b in _context.MsUsers
                            on a.UserID equals b.UserID
                            join c in _context.MsStationeries
                            on a.StationeryID equals c.StationeryID
                            where a.StationeryID == stationeryID && a.UserID == userID
                            select new CartDisplayModel()
                            {
                                UserID = a.UserID,
                                StationeryID = a.StationeryID,
                                UserName = b.UserName,
                                StationeryName = c.StationeryName,
                                StationeryPrice = c.StationeryPrice,
                                Quantity = a.Quantity,
                                TotalPrice = a.Quantity * c.StationeryPrice,
                            }).FirstOrDefault();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        public void InsertCart(Cart cart)
        {
            try
            {
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            catch
            {
                return;
            }
        }

        public Cart UpdateCart(Cart cart)
        {
            try
            {
                Cart temp = (from a in _context.Carts
                             where a.UserID == cart.UserID && a.StationeryID == cart.StationeryID
                             select a).FirstOrDefault();

                temp.Quantity = cart.Quantity;
                _context.SaveChanges();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public List<Cart> DeleteCartByUserID(int userID)
        {
            try
            {
                List<Cart> temp = (from a in _context.Carts
                                   where a.UserID == userID
                                   select a).ToList();
                _context.Carts.RemoveRange(temp);
                _context.SaveChanges();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public Cart DeleteCartByBothCredential(int userID, int stationeryID)
        {
            try
            {
                Cart temp = (from a in _context.Carts
                             where a.UserID == userID && a.StationeryID == stationeryID
                             select a).FirstOrDefault();
                _context.Carts.Remove(temp);
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