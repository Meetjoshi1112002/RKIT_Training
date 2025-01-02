using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Basics
{
    public class ListBasics
    {
    public static bool isJoshi(string s)
    {
            // great concept here:
            //  C#, the == operator is overloaded for strings.
            //It first checks if the two references point to the same object.
            //If the references differ, it checks if the contents of the strings are the same.

            //if (s == "joshi") return true;
            //return false;
            return (s == "joshi");
    }
        public static void display()
        {
            string[] arr = new string[] { "Meet", "Jay", "Joshi" };
            List<string> list = new List<string>(arr);

            // Add elements to the list
            list.Add("Jay");
            list.AddRange(arr);

            // Indexer to access elements
            Console.WriteLine("Element at index 2: " + list[2]);

            // Remove specific item
            list.Remove("Meet");

            // Predicate for RemoveAll
            bool isJoshi(string x) => x == "Joshi";
            list.RemoveAll(isJoshi);

            // Contains method
            Console.WriteLine("Contains 'Jay': " + list.Contains("Jay"));

            // Find method
            string found = list.Find(x => x.StartsWith("J"));
            Console.WriteLine("First element starting with 'J': " + found);

            // FindIndex method
            int index = list.FindIndex(x => x == "Jay");
            Console.WriteLine("Index of 'Jay': " + index);

            // Insert at a specific index
            list.Insert(1, "InsertedValue");
            Console.WriteLine("After Insert:");
            list.ForEach(x => Console.WriteLine(x));

            // Reverse the list
            list.Reverse();
            Console.WriteLine("\nReversed List:");
            list.ForEach(x => Console.WriteLine(x));

            // Sort the list
            list.Sort();
            Console.WriteLine("\nSorted List:");
            list.ForEach(x => Console.WriteLine(x));

            // Convert to array
            string[] convertedArray = list.ToArray();
            Console.WriteLine("\nConverted Array:");
            foreach (var item in convertedArray)
            {
                Console.WriteLine(item);
            }

            // Clear the list
            list.Clear();
            Console.WriteLine("\nList Cleared. Count: " + list.Count);
        }

        public static void display(List<int> num)
        {
            // remove duplicates
            // Difference between IList and List
            // IList is a interface which is implemented by a List and Array
            // List is a class that implements IList

            // So Ilist cannot be instanceciated but can be used to point its implementations

            // IList<Ilist<int>> A = new List<Ilist<int>>  ------->valid
            // IList<Ilist<int>> A = new List<list<int>>  ------->INvalid (as need to explictly convert 

            // problem is like:
                            //you promised to return a bag(IList) full of small bags(IList<int>).
                            //Instead, you gave a bag (List) full of boxes (List<int>).
                            //The compiler can't assume that "boxes" are valid "small bags" even if they might be compatible.
                            //You need to explicitly tell it you're using small bags (IList<int>).
        }
    }
}
