using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public class UserRepository
    {
        Database1Entities1 _context = DatabaseSingleton.getInstance();

        public List<MsUser> GetAllUsers()
        {
            try
            {
                return _context.MsUsers.ToList();
            }
            catch
            {
                return null;
            }
        }

        public MsUser GetById(int userID)
        {
            try
            {
                return (from a in _context.MsUsers
                        where a.UserID == userID
                        select a).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public MsUser GetByUserName(string userName)
        {
            try
            {
                return (from a in _context.MsUsers
                        where a.UserName == userName
                        select a).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void AddUser(MsUser user)
        {
            try
            {
                _context.MsUsers.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
        public MsUser UpdateUserByID(int id, MsUser user)
        {
            try
            {
                MsUser temp = (from a in _context.MsUsers
                               where a.UserID == id
                               select a).FirstOrDefault();
                temp.UserName = user.UserName;
                temp.UserPhone = user.UserPhone;
                temp.UserAddress = user.UserAddress;
                temp.UserPassword = user.UserPassword;
                temp.UserGender = user.UserGender;
                temp.UserDOB = user.UserDOB;   
                _context.SaveChanges();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public MsUser UpdateUserByUserName(MsUser user)
        {
            try
            {
                MsUser temp = (from a in _context.MsUsers
                               where a.UserName == user.UserName
                               select a).FirstOrDefault();
                temp.UserName = user.UserName;
                temp.UserPhone = user.UserPhone;
                temp.UserAddress = user.UserAddress;
                temp.UserPassword = user.UserPassword;
                temp.UserRole = user.UserRole;
                _context.SaveChanges();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public MsUser DeleteUser(int userID)
        {
            try
            {
                MsUser temp = (from a in _context.MsUsers
                               where a.UserID == userID
                               select a).FirstOrDefault();
                _context.MsUsers.Remove(temp);
                _context.SaveChanges();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public MsUser Login(string userName, string userPassword)
        {
            try {
                MsUser temp = (from a in _context.MsUsers
                               where a.UserName == userName && a.UserPassword == userPassword
                               select a).FirstOrDefault();

                if (temp != null)
                {
                    return temp;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}