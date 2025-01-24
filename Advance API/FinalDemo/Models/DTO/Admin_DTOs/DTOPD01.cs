using FinalDemo.Models.POCO;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO.Admin_DTOs
{
    public class DTOPD01
    {
        [JsonProperty("Id")]
        public int D01F01 { get; set; } // ID of PD

        [JsonProperty("Name")]
        public string D02F02 { get; set; } // Name of Pd

        [JsonProperty("PrintingSpec")]

        public string D03F03 { get; set; } // Printing spec

        [JsonProperty("LocationId")]
        public int D04F04 { get; set; } //Location of PD

        [JsonProperty("CreatorId")]
        public int D05F05 { get; set; } // Id of Admin who created him
    }
}