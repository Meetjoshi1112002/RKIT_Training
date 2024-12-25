using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_API.NonPrimitiveDT
{
    public class Arrays
    {
        
        public static void display()
        {
            // use var as clean code to declare arrays
            var intArray = new int[3]; // without inaitlzaiton 

            var stringArray = new string[3] { "Meet" ,"Jay","Dharam"}; // with initalzation

            //There are 2 types of 2D array
            int[,] rectuanguar2D = new int[2,2]{ { 1, 20 }, { 2, 20 } };
            int[][] jaggered2d = new int [3][];

            jaggered2d[0] = new int[] { 1, 2 };

            // some important 2D array methods
            
            var arr = new int[]{2,3,4,5,6,7,8};

            //length property (non static)
            Console.WriteLine(arr.Length);

            //IndexOf (static) returns -1 when not found
            Console.WriteLine(Array.IndexOf(arr,5));

            //Clear (static) makes the 0
            Array.Clear(arr, 2, 3);

            //Sort and reverse (static)
            Array.Sort(arr);
            Array.Reverse(arr);

            //Copy method
            var nwArr = new int[3][];
            Array.Copy(arr, nwArr, 3);

            foreach( var i in arr )
                Console.WriteLine(i);

            Console.WriteLine( stringArray); // show type
            Console.WriteLine(intArray);
            Console.WriteLine(stringArray[1]);

        }
    }
}
