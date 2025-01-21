namespace Advance_API._8_TypeOfClasses
{

    /* static class
     * 
     * contains only static members. no instance variables allowed.
     * 
     * no instances of such classes.
     * 
     * static classes are sealed, so can't be inherited.
     * 
     * only static constructor are allowed.
     * 
     * Generally used to create Service Provider which is independ of environemnt or In memory repository
    */

    static class StaticClass
    {
        public static string user;
        internal static void GreetUser()
        {
            Console.WriteLine($"Hello {user}");
        }

        // constructor
        static StaticClass()
        {
            // no parameters allowed as these are called automatically
            // are called only once in their lifetime
            Console.WriteLine("Static Constructor");
            user = "Demo";
        }
    }
}
