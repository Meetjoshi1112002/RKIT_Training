using System.Security.Principal;

namespace Basic_API.NonPrimitiveDT
{
    public class StringBasics
    {
        public static string summerizer(string s) {
            const int maxSize = 10;
            if (s.Length < maxSize)
            {
                return s;
            }
            var words = s.Split(' ');
            int currentLength = 0;
            var wordUsage = new List<string>();

            foreach (var word in words) { 
                wordUsage.Add(word);
                currentLength += (word.Length + 1);
                if (currentLength > maxSize) {
                    break;
                }
            }

            return String.Join(" ", wordUsage) + "...";

        }
        public static void display()
        {
            Console.WriteLine("Most Important part started now");

            // All primitave DT of C# are basically alias of struct of .net framework

            // int == System.Int32 , char == System.Char ,, so on

            // So all C# Primitave DT are mapped to .net framework DT during compilation

            // this is useful as well as sturt have many methods and DT which we can use in C#

            int i = 10;
            System.Int32 j = 10; // Int32 is a struct


            // However string in .net framework is a Class !
            var firstName = "Meet";
            var lastName = "Joshi";
            String meth1 = String.Format("My name is {0} {1}", firstName, lastName);

            // we can make a string from string array directy with our own seperator
            var strArr = new String[3] { "Meet", "Jay", "Dharam" };
            var newS = string.Join("-", strArr);

            //verbian string
            var oldMethod = "\\local\\path\nOldWay";
            var newWay = @"\local\path
newWay";
            Console.WriteLine(newWay);


            // string methods (always remeber that they are immutable)

            var name = "Meet Joshi    ";

            var newNmae = name.Trim();
            Console.WriteLine(newNmae);

            // 1st find out first name and last name
            //two ways
            var indexSpace = name.IndexOf(' ');
            var fn = name.Substring(0, indexSpace);
            var ln = name.Substring(indexSpace + 1);
            Console.WriteLine(firstName+" "+ lastName);

            var narr = name.Split(" ");
            Console.WriteLine(narr[0] + " " + narr[1]);

            // other important method : Replace
            Console.WriteLine(name.Replace("Meet","Jay"));

            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Exectue when given string is null or empty");
            }

            // howerver dont work for whitespcace and we need to treim first 

            if (String.IsNullOrWhiteSpace(name)) {
                Console.WriteLine("Even single white space cannot excpae here");
            }

            int num = 0;

            var strN = num.ToString();
            strN = Convert.ToString(num);
            Console.WriteLine(strN);

            var stringVal = "33";
            int numVla = Convert.ToInt32(stringVal);

            //every object in C# have .tostirng method
            float price = 12.5f;
            Console.WriteLine(price.ToString("C0")); // currency format

        }
    }
}
