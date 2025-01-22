using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API.LambdaExpression
{
    /*
     * Lambda Expresson
     * 
     * Has no accesmodifier no return type and no name !
     * 
     * used for convivence and less code - more readble 
     * 
     * Syntax : args => expressoin
     * 
     * Assign it to a deligate
     * 
     * ()=> ...
     * x => ....
     * (x,y,z) => ...
     * 
     * Lambda has access of varibale of scopes where it is declared
     * 
     * Usagae :> Generally used in Find family method of all collections
     */
    internal static class Demo2
    {
        public static readonly List<int> myList = new() { 1,2,3,4,5,6,7,8,9,10};

        public static List<int> GetEvens => myList.FindAll(x => x % 2 == 0); // used lambda expression as predication
                                                                             // we all know that predicate is also a type of deligate

        public static void display()
        {

            Func<int, int, int> Product = (m, n) =>
            {
                Console.WriteLine("THis is m : " +m);
                Console.WriteLine("THis is n :"+n);
                return m * n;
            };

            Console.WriteLine(Product(5,4));
        }
    }
}
