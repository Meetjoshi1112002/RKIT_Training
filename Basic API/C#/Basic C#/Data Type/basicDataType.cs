using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Basic_API.Data_Type
{
    internal class BasicDT
    {
        public static void display() {
            // integer data types and thier sizes: (here default is int)
            long l = 0; //8
            int n = 0; // 4
            short s = 20; // 2
            byte b = 255; // 1

            var @int = 5; // proves default is int



            // real numbers and thier sizes (here defaul is double)
            float fl = 0.0f; // 4
            double d = 1.2;  // 8
            decimal dc = 10.5m; // 16

            var def = 0.55; // double 
            int smaple = 5;
            //sample.tostring();


            // boolean data type
            var boolDT = 0; // 1

            // character DT
            char name = 'A'; //2

            //constant which cannot be futher modified
            const float pi = 3.14f;

            // find code that reamins only during develoopment phase and get auto removed during deployment
            //use checked to prevent overflow
            checked
            {
                //b = b + 1; // here error will be thrown that prevents overflow
            }


            Console.WriteLine("{0}  {1} {2}" , l,n,@int); // string formating
        }
    }
}
