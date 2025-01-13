using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM_Demo.Models.Enum;

namespace ORM_Demo.Models.POCO
{
    public class Admin
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Unique]
        public string password { get; set; }

        [Required]
        public AdminRole Role { get; set; }
    }
}
