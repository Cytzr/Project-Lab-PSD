using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Factories
{
    public class MsUserFactory
    {
        public static MsUser create_user(string userName, string userGender, DateTime userDOB, string userPhone, string userAddress, string userPassword, string userRole)
        {
            MsUser user = new MsUser()
            {
                UserName = userName,
                UserGender = userGender,
                UserDOB = userDOB,
                UserPhone = userPhone,
                UserAddress = userAddress,
                UserPassword = userPassword,
                UserRole = userRole
            };

            return user;
        }
    }
}