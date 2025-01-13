using ORM_Demo.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Demo.Models.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AdminRole Role { get; set; }
    }
}
