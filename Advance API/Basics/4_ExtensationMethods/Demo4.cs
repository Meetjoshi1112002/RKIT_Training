using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Extension Mehtod theory:
 * 
 * Allow us to add methods to an exitsing class without changing its source code
 * 
 * Or  Creating a new class that inherits from it (also for sealed class like String)
 * 
 * Eg: we want to add our cutom mehtod to string class --> then only extension methods will help us
 * 
 * Convetinon Rules:
 * 
 * 1st : create a static class (with ClassName you are extending and append Extension)
 * 
 * 2nd : then create the static mehtod that we want to add to that class
 * 
 * 3rd : First parameter should always be (this class_name var) that we are extending
 * 
 * 4th : Then ExtensionMethod created static class must be in same namespace where we are using it
 * 
 * 5th : Tip: while extending System class, Put your static class dirclty in the System namespace as we are alreading using ti most time
 * 
 * 6th : Generally Extension methods are less created and more used
 *       Suppose i add a extension method for string in system and microsoft added a method with same name is source code , then it will have more priority 
 *       For fun fact , linq has all extesnsion methods for most System classes in C# which is conver in Linq modules
 
 */

namespace Advance_API._4_ExtensationMethods
{
    internal class Demo4
    {
        public static void display()
        {
            // Demo of extending custom class
            Meet m = new();
            m.DisplayDetail();

            // Demo of System class String extension
            "Meet".JoshisMethod();
        }

    }
}

namespace System
{
    public static class StringExtension
    {
        public static void JoshisMethod(this string str)
        {
            Console.WriteLine("This is My method for stgring extended in System namespace so that can direcly use without other imports");
        }
    }
}