namespace Basic_API.NonPrimitiveDT
{
    public class Person
    {
        public int Age;
    }


    public class ValueReference
    {
        public static void display()
        {
            // C# has basically two types of implementaion
            //1st Structures  : is value type 
            //Stored on stack
            // managed by CLR
            // eg: primitive data type , custom sturtures

            // 2nd Classes    : is refernce type
            // stored on heap
            // managed by GC
            //eg : Array , String , other custom classes

            // example
            var num = 10;
            increment(ref num);
            Console.WriteLine(num);
            
            var p = new Person() { Age = num };
            changeAge(p);
            Console.WriteLine(p.Age);

        }

        public static void increment(ref int number)
        {
            number++;
        }

        public static void changeAge(Person p)
        {
            p.Age++;
        }
    }
}
