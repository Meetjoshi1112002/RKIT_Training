using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUD_Demo.Models.DTO
{
    public class DTOEMP01
    {
        [JsonPropertyName("P01101")]
        [Required(ErrorMessage = "UserId is required.")]
        public int P01F01 { get; set; }   // user id

        [JsonPropertyName("P01102")]
        [Required(ErrorMessage = "name is required.")]
        public string P01F02 { get; set; }  // usre name

        [JsonPropertyName("P01103")]
        [Required(ErrorMessage = "email is required.")]
        public string P01F03 { get; set; } // user email

        [JsonPropertyName("P01104")]
        [Required(ErrorMessage = "Password is required.")]
        public string P01F04 { get; set; } // user password
    }
}
