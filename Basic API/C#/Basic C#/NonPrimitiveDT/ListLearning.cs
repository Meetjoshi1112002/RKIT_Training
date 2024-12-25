using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_API.NonPrimitiveDT
{
    public class ListLearning
    {
        public static void display()
        {
            // List 
            var numbers = new List<int>() { 1, 2, 3 };

            // improtant list methods
            numbers.Add(10); // Adds 10 to the list

            numbers.Add(20); // Adds 20 to the list

            var arrayToadd = new List<int>() { 1, 2, 3 }; //can be array as well

            // Inumberable used interface can have list or array
            numbers.AddRange(arrayToadd); // Adds 3, 4, and 5 to the list

            numbers.Remove(3); // Removes the first occurrence of 3

            // we cannot modify any collections in foreach loop (it would thorw a exeption)
            // however we can do in noral for loop

            //foreach (var number in numbers) {
            //    if (number == 1) {                            ---------------->> Errror will be thrown
            //        numbers.Remove(number);
            //    }
            //}

            numbers.RemoveRange(1, 2); // Removes 2 elements starting at index 1 (2 and 3)


            bool hasThree = numbers.Contains(3); // true

            int index = numbers.IndexOf(2); // Returns 1 (index of the first occurrence of 2)

            int lastIndex = numbers.LastIndexOf(2); // Returns 3 (index of the last occurrence of 2)

            int count = numbers.Count; // Returns lenght of list

            numbers.Reverse(); // List becomes { 3, 2, 1 }

            numbers.Insert(1, 10); // add at specified poistin (O(n) operation as not append)

            int result = numbers.Find(x => x > 2); // Finds the first element matching a condition.

            List<int> results = numbers.FindAll(x => x > 2); // returns all items with given coidtions

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            numbers.Clear(); // List is now empty


        }
    }
}
