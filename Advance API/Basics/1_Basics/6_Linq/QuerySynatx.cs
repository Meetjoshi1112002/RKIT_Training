using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Deferred Execution:
 * 
 * Query are not executed at the time we create them
 * 
 * Executed when: 
 *              1st : loop over variable
 *              2nd : Called .TOList(), TOArrayOr To dictorinary
 *              3rd : calling first last ..etc agggreagte funcitons
 *              
 *              
 
 */

namespace Advance_API._6_Linq
{
    public static class Demo6Extension
    {
        // Query Syntax Demonstration
        public static void QuerySyntax(this Demo6 obj)
        {
            // Dummy Data: Lists of Customers and Orders
            List<Customer> _customerList = DummyDataRepository.GetCustomers();
            List<Order> _orderList = DummyDataRepository.GetOrders();

            // ******************************************************************
            // 1. Simple Filtering and Ordering in Query Syntax
            var r1 = from c in _customerList                  // Source: Customer List
                     where c.Age > 20 && c.Age < 40          // Filter: Age between 20 and 40
                     orderby c.Name ascending, c.Age descending // Sort by Name (ascending), Age (descending)
                     select new
                     {
                         Name = c.Name,                      // Project Name
                         Age = c.Age                         // Project Age
                     };

            // ******************************************************************
            // 2. Grouping Without Aggregation
            IEnumerable<IGrouping<dynamic, Order>> groups = from o in _orderList   // Group by CustomerId and OrderDate
                                                            group o by new { o.CustomerId, o.OrderDate }
                                                            into g
                                                            select g;

            /* Uncomment to inspect group contents
            foreach (IGrouping<dynamic, Order> g in groups)
            {
                Console.WriteLine("Group Key: " + g.Key);
                Console.WriteLine("Order Count: " + g.Count());  // Aggregation on the group
                foreach (Order o in g)
                {
                    Console.WriteLine(o.Id + " " + o.OrderDate);   // Display individual order details
                }
            }
            */

            // ******************************************************************
            // 3. Inner Join in LINQ (Similar to SQL JOIN)
            IEnumerable<dynamic> r2 = from c in _customerList
                                      join o in _orderList on c.Id equals o.CustomerId // Inner Join
                                      select new { c.Name, o.OrderDate };

            foreach (var i in r2)
            {
                Console.WriteLine(i.Name + " " + i.OrderDate);  // Displaying the result of the join
            }

            // ******************************************************************
            // 4. Group Join (Left Join) in LINQ (Unique to LINQ)
            IEnumerable<dynamic> r3 = from c in _customerList                                   // Parent: Customer List
                                      join o in _orderList on c.Id equals o.CustomerId into g  // Group join to get orders
                                      select new { c.Name, OrderCount = g.ToList() };          // Orders as a list

            /* Uncomment to inspect the group join result
            foreach (var i in r3)
            {
                // Type of i: { string, List<Order> }
                Console.WriteLine(i.Name + " has " + i.OrderCount.Count + " orders");
            }
            */

            // ******************************************************************
            // 5. Cross Join (All Combinations) - Using SelectMany
            IEnumerable<dynamic> r4 = from c in _customerList   // Cartesian Product (Cross Join)
                                      from o in _orderList
                                      select new { c.Name, o.OrderDate };
        }

        // Extension Syntax Demonstration (Method Syntax)
        public static void ExtensionSyntax(this Demo6 obj)
        {
            // Dummy Data: Lists of Customers and Orders
            List<Customer> _customerList = DummyDataRepository.GetCustomers();
            List<Order> _orderList = DummyDataRepository.GetOrders();

            // ******************************************************************
            // 1. Simple Query with Filtering, Ordering, and Projection
            IEnumerable<dynamic> sample = _customerList
                                            .Where(c => c.Age > 35 && c.Age < 45)  // Filter: Age between 35 and 45
                                            .OrderBy(c => c.Name)                  // Sort: Name ascending
                                            .ThenBy(c => c.Age)                    // Then: Age ascending
                                            .Select(c => new { c.Name, c.Age });   // Project Name and Age



            // ******************************************************************
            // 2. Flattening a List of Lists using SelectMany
            var demoData = new List<List<int>>()
            {
                new List<int>(){ 1, 2, 3 },
                new List<int>(){ 1, 2, 4, 5 }
            };

            IEnumerable<int> falten = demoData
                                        .SelectMany(c => c)  // Flatten nested lists into a single list
                                        .Distinct();         // Remove duplicate values

            // Uncomment to inspect the flattened result
            // foreach (int i in falten)
            //     Console.WriteLine(i);

            // ******************************************************************
            // 3. Grouping with GroupBy
            IEnumerable<IGrouping<int, Customer>> grps = _customerList.GroupBy(c => c.Age);  // Group customers by age

            // ******************************************************************
            // 4. Join Examples

            // 1st: Inner Join using Method Syntax
            dynamic result = _customerList.Join(_orderList,                           // Join Customers with Orders
                                                c => c.Id,                          // Join condition: Customer Id
                                                o => o.CustomerId,                  // Join condition: Order CustomerId
                                                (c, o) => new { c.Name, o.OrderDate }); // Result: Name and OrderDate

            // 2nd: Group Join (Equivalent to Left Join)
            var result2 = _customerList.GroupJoin(_orderList,                          // Group Customers with Orders
                                                  c => c.Id,                         // Join condition: Customer Id
                                                  o => o.CustomerId,                 // Join condition: Order CustomerId
                                                  (c, o) => new { c, o });           // Result: Customer and Orders list

            // 3rd: Cross Join using SelectMany
            var res3 = _customerList.SelectMany(
                                                    c => _orderList,                // Outer collection: _customerList
                                                    (c, o) => new { c, o }          // Projection: Combine Customer and Order
                                                );

            // ******************************************************************
            // 5. Partitioning (Skip and Take)
            var res4 = _customerList.Skip(10).Take(10);  // Skip first 10, take the next 10 customers

            // ******************************************************************
            // 6. Element Operators (First, Last, Single)
            // .First(predicate)         --> Throws exception when not found
            // .FirstOrDefault(predicate) --> Returns default value when not found
            // .Last(predicate)           --> Similar to First, but from the end
            // .LastOrDefault(predicate)  --> Returns default value when not found
            // .Single(predicate)         --> Throws exception if multiple matches
            // .SingleOrDefault(predicate)--> Returns default value if no match

            // ******************************************************************
            // 7. Quantifier Operators (All, Any)
            // .All(predicate)            --> Checks if all elements satisfy the predicate
            // .Any(predicate)            --> Checks if any element satisfies the predicate

            // ******************************************************************
            // 8. Aggregation Functions (Count, Max, Min, Sum, Average)
            // .Count()   --> Count the elements
            // .Max()     --> Find the maximum value
            // .Min()     --> Find the minimum value
            // .Sum()     --> Sum of values
            // .Average() --> Average of values

            IQueryable<Customer> sampleData = (IQueryable<Customer>) _customerList.Where(c => c.Id == 1);   // Iquerable is game changer as apply all linq aggreageted on the external DB


            // BUT ORMLITE DOESNT SUPPORT IQuerable !
        }
    }
}


