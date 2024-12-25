using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_API.Date
{
    public class LearningDates
    {
        public static string setDeadline()
        {
            // Note : Date object in C# are immutable and are impleted as strutucre in .net
            // let us create assume someProffesor created a assignment and we want to automate setting deadline to it

            var dateObject = new DateTime();

            // Now propery is a object represting current Date object
            var today = DateTime.Now;

            var deadline = today.AddDays(3); // we can also go backward

            //Console.WriteLine(deadline); // when used directly calls .ToString() method

            // ToString has optional format parater
            //ie:TOStirng("dd-mm-yyyy") to get date in speicfied formate

            return deadline.ToString("f"); // full time with time

        }
    }
}
