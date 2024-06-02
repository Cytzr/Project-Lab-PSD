using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab_PSD.Response
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public String Message { get; set; }
        public T PassValue { get; set; }
    }
}