using ServiceStack.DataAnnotations;

namespace FinalDemo.Models.POCO
{
    public class ADM01
    {
        [PrimaryKey]
        public int M01F01 { get; set; }   // Id

        [Required]
        public string M01F02 { get; set; } // Amdin name

        [Required]
        public string M01F03 { get; set; } // Admin Password

        [Required]
        public int M01F04 { get; set; } // admin role
    }
}