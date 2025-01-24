using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


// DTO for creation and update
namespace ORM_Final_Demo.Models.DTO
{
    public class DTOEMP01
    {
        [JsonProperty("P01101")]
        [Required(ErrorMessage = "UserId is required.")]
        public int P01F01 { get; set; } // user id

        [JsonProperty("P01102")]
        [Required(ErrorMessage = "Username is required.")]
        public string P01F02 { get; set; } // user name

        [JsonProperty("P01104")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
        public string P01F04 { get; set; } // password for user

        [JsonProperty("P01103")]
        [Required(ErrorMessage = "Creation Date is required.")]
        public DateTime P01F03 { get; set; } //birthday of user

    }
}
