using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.POCO
{
    public class PD01
    {
        [PrimaryKey]
        public int D01F01 { get; set; } // ID of PD

        [Required]
        public string D02F02 { get; set; } // Name of Pd

        [Required]
        public string D03F03 { get; set; } // Printing spec

        [Required]
        public int D04F04 { get; set; } //Location of PD

        [Required]
        [References(typeof(ADM01))]
        public int D05F05 { get; set; } // Id of Admin who created him
    }
}