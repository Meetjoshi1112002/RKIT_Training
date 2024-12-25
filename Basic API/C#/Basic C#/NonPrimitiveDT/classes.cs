using System.Runtime.CompilerServices;

namespace Basic_API.NonPrimitiveDT
{
    public class Telephone
    {
        static int count = 0;
        // such static methods dont have implicit this pointer which is there implicitly in all non static methods
        public static void showTotalNumbers()
        {
            Console.WriteLine("Total number of numbers in directory is " + count);
        }

    }
}
