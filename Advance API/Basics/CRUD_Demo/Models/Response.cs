using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Demo.Models
{
    public class Response
    {
        public dynamic data { get;set; }

        public string Message { get; set; }

        public bool ErrorStatus { get; set; }
    }
}
