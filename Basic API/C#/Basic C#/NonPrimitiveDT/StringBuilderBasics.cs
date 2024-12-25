using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_API.NonPrimitiveDT
{
    public class StringBuilderBasics
    {
        public static void display()
        {
            var sb = new StringBuilder("Meet joshi");
            sb.Append("Hellow orld")
                .AppendLine()
                .Replace("Hell", "----")
                .Remove(0, 3)
                .Insert(5, "Sample");
            Console.WriteLine(sb); ;

            
        }
    }
}
