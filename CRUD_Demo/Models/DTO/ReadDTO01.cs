using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRUD_Demo.Models.DTO
{
    internal class ReadDTOEMP01
    {
        [JsonPropertyName("P01101")]
        public int P01F01 { get; set; }   // user id

        [JsonPropertyName("P01102")]
        public string P01F02 { get; set; }  // usre name

        [JsonPropertyName("P01103")]
        public string P01F03 { get; set; } // user email

        [JsonPropertyName("Some Extra detials")]
        public int P01F04 => GetEmailLength(P01F03);


        private int GetEmailLength(string email)
        {
            return email.Length;
        }
    }
}
