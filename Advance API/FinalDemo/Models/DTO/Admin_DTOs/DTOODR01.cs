using FinalDemo.Models.POCO;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.DTO.Admin_DTOs
{
    public class DTOODR01
    {
        [JsonProperty("Id")]
        public int R01F01 { get; set; } // Order Id

        [JsonProperty("PrintingSpec")]
        public string R01F02 { get; set; } // PS of order

        [JsonProperty("CreatorId")]
        [References(typeof(ADM01))]
        public int R01F03 { get; set; } // Admin who created it

        [JsonProperty("Pincode")]
        public string Pincode { get; set; } // Pincode field

        // Location Id is a calculated field based on the Pincode
        [JsonProperty("Location Id")]
        public int R01F06 => SetCode(Pincode);

        [JsonProperty("AssigneeId")]
        [References(typeof(PD01))]
        public int R01F04 { get; set; } // PD which is assigned to it, can be null 

        // Method to set the Location Id based on the first character of Pincode
        private int SetCode(string pincode)
        {
            if (string.IsNullOrEmpty(pincode) || pincode.Length < 1)
            {
                return 0; // Return a default value if Pincode is null or empty
            }

            // Use the first character of the Pincode and convert it to an integer
            if (int.TryParse(pincode[0].ToString(), out int code))
            {
                return code;
            }

            return 0; // Return a default value if parsing fails
        }
    }
}
