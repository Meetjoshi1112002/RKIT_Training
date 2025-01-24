using FinalDemo.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo.Models.DTO.Admin_DTOs
{
    public class DTOVIEW01
    {
        public string Admin { get; set; }

        public List<PD01> Printers_Created { get; set; }

        public List<ODR01> Orders_Created { get; set; }
    }

    public class OrderDetails
    {
        public int Order_ID { get; set; }

        public string PrintingSpec { get; set; }
        public DateTime Creation_Time { get; set; }

        //public ADM01 Creator { get; set; }
    }

    public class OrderDetails2
    {
        public int OrderId { get; set; }        // Maps to R01F01 (Order ID)
        public DateTime CreatedAt { get; set; }  // Maps to R01F05 (Order creation time)
        public string Creator { get; set; }      // Maps to M01F02 (Admin name)
        public int CreatorRole { get; set; }  // Maps to M01F04 (Admin role)
        public string Printer { get; set; }      // Maps to D02F02 (Printer name)
        public string PrintingSpec { get; set; } // Maps to R01F02 (Printing spec of order)
    }


}