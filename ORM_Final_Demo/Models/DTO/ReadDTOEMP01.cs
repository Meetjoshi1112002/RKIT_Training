using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

// Read DTO should not have password

namespace ORM_Final_Demo.Models.DTO
{
    public class ReadDTOEMP01
    {
        [JsonProperty("P01101")]
        [Required(ErrorMessage = "UserId is required.")]
        public int P01F01 { get; set; } // user id

        [JsonProperty("P01102")]
        [Required(ErrorMessage = "Username is required.")]
        public string P01F02 { get; set; } // user name


        [JsonProperty("P01103")]
        [Required(ErrorMessage = "Creation Date is required.")]
        public DateTime P01F03 { get; set; } // birthday of user

        // Read-only property to calculate age based on P01F03 (birthdate)
        [JsonProperty("P01105")]
        public int P01F05 => CalculateAge(P01F03); // Age property calculated from birthdate
        

        // Method to calculate age
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            // If the birthday hasn't occurred yet this year, subtract one year from the age
            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
