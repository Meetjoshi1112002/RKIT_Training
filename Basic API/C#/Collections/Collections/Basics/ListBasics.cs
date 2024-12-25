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

        if (s == "joshi") return true;
        return false;
    }
        public static void display()
        {
            //List
            // List has concept of count and capacity internally
            // when count > capacity then an internal algo copies all ele in a new bigger list and increase capacity
            string[] arr = new string[] { "Meet","Jay", "joshi"};
            List<string> list = new List<string>(arr);

            list.Add("Jay");
            list.AddRange(arr);

            // indexer to access
            //Console.WriteLine(list[2]);
            
            list.Remove("Meet");

            
            list.RemoveAll(isJoshi);

            //forEach method (lambda expression)
            list.ForEach(x => Console.WriteLine(x));


            Console.WriteLine();
            list.Clear();
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
