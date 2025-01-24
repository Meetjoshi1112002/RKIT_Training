using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Final_Demo.Models
{
    public class Response
    {
        public dynamic Data { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
    }
}
