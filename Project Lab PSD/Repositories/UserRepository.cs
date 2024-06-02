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
            return _context.MsUsers.ToList();
        }

        public MsUser GetById(int userID)
        {
            return (from a in _context.MsUsers
                    where a.UserID == userID
                    select a).FirstOrDefault();
        }

        public MsUser GetByUserName(string userName)
        {
            return (from a in _context.MsUsers
                    where a.UserName == userName
                    select a).FirstOrDefault();
        }

        public void AddUser(MsUser user)
        {
            _context.MsUsers.Add(user);
            _context.SaveChanges();
        }

        public MsUser UpdateUserByID(MsUser user)
        {
            MsUser temp = _context.MsUsers.Find(user.UserID);
            temp.UserName = user.UserName;
            temp.UserPhone = user.UserPhone;
            temp.UserAddress = user.UserAddress;
            temp.UserPassword = user.UserPassword;
            temp.UserRole = user.UserRole;
            _context.SaveChanges();
            return temp;
        }

        public MsUser UpdateUserByUserName(MsUser user)
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

        public MsUser DeleteUser(int userID)
        {
            MsUser temp = (from a in _context.MsUsers
                           where a.UserID == userID
                           select a).FirstOrDefault();
            _context.MsUsers.Remove(temp);
            _context.SaveChanges();
            return temp;
        }

        public MsUser Login(string userName, string userPassword)
        {
            MsUser temp = (from a in _context.MsUsers
                           where a.UserName == userName && a.UserPassword == userPassword
                           select a).FirstOrDefault();

            if (temp != null)
            {
                return temp;
            }
            return null;
        }
    }
}