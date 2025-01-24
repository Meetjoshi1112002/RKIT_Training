using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models
{
    public class Response
    {
        public dynamic Data { get; set; }

        public bool IsError { get; set; }

        public string Message { get; set; }
    }
}