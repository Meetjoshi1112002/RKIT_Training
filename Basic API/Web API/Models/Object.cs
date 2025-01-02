namespace Web_API.Models
{
    public class Order
    {
        public static int id = 5;
        public int OrderId { get; private set; } // Read-only property for Order ID
        public string Name { get; set; } // Property for Name
        public string Spec { get; set; } // Property for Spec

        public Order() { }

        public Order(string name, string spec)
        {
            id++;
            OrderId = id;
            Name = name;
            Spec = spec;
        }
    }
}
