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
            // explore more useful propertys of DateTime

            DateTime dateObject = new DateTime();

            // Now propery is a object represting current Date object
            DateTime today = DateTime.Now;

            DateTime deadline = today.AddDays(3); // we can also go backward
            Console.WriteLine(DateTime.UtcNow); // univeral time 

            // convert universal time to a country time

            //Console.WriteLine(deadline); // when used directly calls .ToString() method

            // ToString has optional format parater
            //ie:TOStirng("dd-mm-yyyy") to get date in speicfied formate

            return deadline.ToString("f"); // full time with time


            // Time span 
            // date of two date object is time span
            DateTime today1 = DateTime.Now;
            DateTime tommorow = DateTime.Now.AddDays(1);

            TimeSpan t = tommorow - today1;
            Console.WriteLine(t.ToString());

            // we can compare two date

            int ans = DateTime.Compare(today1, tommorow);
            // 0 if both same 
            // 1 if today1 bigger
            // -1 else

            DateTime dt = DateTime.Parse("2024-12-20"); // make a stirng to DateTime

        }
    }
}
