﻿namespace LearningWebApp.Data.Models
{
    public class Order
    {
        public int Id { get; } //Made readonly
        public string Name { get; set; }
        public string PrintingSpecifications { get; set; }
        public int LocationId { get; set; } 

        private static int count;

        public string PrinterId { get; set; } //or we could have direclyl used the reference of PD only
        static Order()
        {
            count = 0;
        }

        public Order(string name, string printingSpecifications, int locationId)
        {
            Id = count++;
            Name = name;
            PrintingSpecifications = printingSpecifications;
            LocationId = locationId;
        }
    }
}