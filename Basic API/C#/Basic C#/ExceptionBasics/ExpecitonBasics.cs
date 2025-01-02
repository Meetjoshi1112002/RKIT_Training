using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In C# throws is not valid

// Despite we can trow expection from methods without handling there

// However its developers role to handle the expcetions



namespace Basic_API.ExceptionBasics
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException():base("This is order exception ") { }

        public InvalidOrderException(string message):base(message) { }
    }
    internal class ExpecitonBasics
    {
        public static void checkOrder(int[] arr)
        {
            if (arr.Length <= 0) throw new InvalidOrderException("Please provide atleast 2 length");

            if (arr[0] > arr[0]) throw new InvalidOrderException();

            Console.WriteLine("Valid order");
        }

        public static void display()
        {
            int[] arr = new int[] { 0, 1 };
            try
            {
                checkOrder(arr);
            }
            catch (InvalidOrderException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("code completed");
            }
        }

    }
}
