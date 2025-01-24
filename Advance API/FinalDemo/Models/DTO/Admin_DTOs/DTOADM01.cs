//DTO for admin creation

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo.Models.DTO.Admin_DTOs
{
    public class DTOADM01
    {
        [JsonProperty("P01101")]
        [Required(ErrorMessage = "admin id is required.")]
        public int M01F01 { get; set; }   // Id

        [JsonProperty("P01102")]
        [Required(ErrorMessage = "admin name is required.")]
        public string M01F02 { get; set; } // Amdin name


        [Required(ErrorMessage = "Password is required.")]
        [JsonProperty("P01103")]
        public string M01F03 { get; set; } // Admin Password

        [JsonProperty("P01104")]
        [Required(ErrorMessage ="ROle is reuquired")]
        public int M01F04 { get; set; } // admin role
    }
}