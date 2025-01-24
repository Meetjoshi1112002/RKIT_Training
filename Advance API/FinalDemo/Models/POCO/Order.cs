using ServiceStack.DataAnnotations;
using System;

namespace FinalDemo.Models.POCO
{
    public class ODR01
    {
        [PrimaryKey]
        public int R01F01 { get; set; } // Order Id

        [Required]
        public string R01F02 { get; set; } // PS of order

        [Required]
        public int R01F06 { get; set; }  // Location of order

        [Required]
        public DateTime R01F05 { get; set; }

        [References(typeof(ADM01))]
        public int R01F03 { get; set; } // Admin who created it

        [References(typeof(PD01))]
        public int R01F04 { get; set; } // PD which is assigned to it , cannot be null
    }
}