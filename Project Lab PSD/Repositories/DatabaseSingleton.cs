using Project_Lab_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Repositories
{
    public static class DatabaseSingleton
    {
        private static Database1Entities1 _context = null;

        public static Database1Entities1 getInstance()
        {
            if (_context == null)
            {
                _context = new Database1Entities1();
            }
            return _context;
        }
    }
}