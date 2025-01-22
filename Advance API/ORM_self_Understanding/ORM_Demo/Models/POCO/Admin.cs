using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM_Demo.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Password { get; set; }

        [Required]
        []
        public AdminRole Role { get; set; }
    }
}
