using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_API.Control_Flow
{
    public class ConditionalStatements
    {
       public static void display()
        {
            // if else same as other languages

            // tertiary operator
            var value = true;

            var assing = (value) ? "Meet" : "Else this will bMeete assigned";

            switch (assing)
            {
                case "Meet":
                    Console.WriteLine("Meet joshi");
                    break;
                case "Joshi":
                    Console.WriteLine("Joshi");
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
        }


    }
}
