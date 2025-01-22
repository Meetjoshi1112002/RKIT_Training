using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Demo.Models
{
    public class Response
    {
        // basically the payload
        public dynamic Data { get; set; }

        // error flag
        public bool IsError { get; set; }

        // error message in case of error
        public string Message { get; set; }
    }
}
