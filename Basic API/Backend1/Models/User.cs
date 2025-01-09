using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend1.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }

    public class TokenDetails
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}