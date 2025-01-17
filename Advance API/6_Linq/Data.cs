using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._6_Linq
{
    public static class DummyDataRepository
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Doe", Age = 30, City = "New York", IsActive = true },
            new Customer { Id = 2, Name = "Jane Smith", Age = 25, City = "Los Angeles", IsActive = false },
            new Customer { Id = 3, Name = "Sam Brown", Age = 35, City = "Chicago", IsActive = true },
            new Customer { Id = 4, Name = "Lisa White", Age = 28, City = "New York", IsActive = true },
            new Customer { Id = 5, Name = "Tom Green", Age = 40, City = "Chicago", IsActive = false },
            new Customer { Id = 6, Name = "Sarah Blue", Age = 22, City = "Los Angeles", IsActive = true },
            new Customer { Id = 7, Name = "Mike Black", Age = 50, City = "Chicago", IsActive = true }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order { Id = 1, CustomerId = 1, Amount = 200, OrderDate = new DateTime(2023, 1, 15) },
            new Order { Id = 2, CustomerId = 2, Amount = 150, OrderDate = new DateTime(2023, 2, 10) },
            new Order { Id = 3, CustomerId = 3, Amount = 300, OrderDate = new DateTime(2023, 3, 5) },
            new Order { Id = 4, CustomerId = 1, Amount = 400, OrderDate = new DateTime(2023, 4, 1) },
            new Order { Id = 5, CustomerId = 4, Amount = 250, OrderDate = new DateTime(2023, 1, 30) },
            new Order { Id = 6, CustomerId = 2, Amount = 120, OrderDate = new DateTime(2023, 5, 25) },
            new Order { Id = 7, CustomerId = 6, Amount = 180, OrderDate = new DateTime(2023, 6, 12) },
            new Order { Id = 8, CustomerId = 3, Amount = 500, OrderDate = new DateTime(2023, 7, 19) }
        };

        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static List<Order> GetOrders()
        {
            return Orders;
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

