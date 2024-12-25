using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Basics
{
    internal class DictioneryBasics
    {
        public static void display()
        {
            //In Dictonery key must be unique and not null
            //StandALone key cannot be used
            Dictionary<string,List<string>>dict = new Dictionary<string, List<string>>()
            {
                {"Dharam", new List<string>(){"LAW", "LLB"} }
            };

            List<string> courses = new List<string> { "DBMS", "C#", "DSA" };

            
            dict.Add("Meet", courses); //Add method
            courses.Add("Jquery");
            dict.Add("JAY", courses);

            
            dict.Remove("JAY"); //Remove method by  specify just a key


            // Iterate over dictionery
            foreach (KeyValuePair<string,List<string>> e in dict)
            {
                Console.WriteLine( "First preference of {0} is {1}", e.Key, e.Value[0]);
            }
            //Console.WriteLine(dict["Meet"][0]); // KeyNotFoundException when key wont be found

            Console.WriteLine(dict.ContainsKey("Meet"));
            Console.WriteLine(dict.ContainsValue(courses)); // check reference first followed by the structure



            //clear method :
            dict.Clear();
        }
    }
}
