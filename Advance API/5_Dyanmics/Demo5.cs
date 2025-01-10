using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
 * Theory of Dynamics:
 * 
 * Made C# dynamically typed language by making type resoltion at runtime
 * 
 * Concept of reflecitn : Reflection in C# is like peeking under the hood of an object at runtime. It allows you to:
                          Inspect metadata (like class structure, methods, properties).
                          Invoke methods or access properties dynamically.
                          Create objects dynamically.
 *
 *
 *In dynamcis we have implict type cast 
 *ie int i = 10 ; dynamc j = i --> here there will be implecit type cast
 *However reflections should be used to prevent run time excetion during method invocations
 */

namespace Advance_API._5_Dyanmics
{
    internal class Demo5
    {
        static public void display()
        {
            //Refleciotn
            // Create an object holding a string value
            object ojb = "Meet";

            var methodInfo = ojb.GetType().GetMethod("GetHashCode"); // Get metadata about the 'GetHashCode' method using reflection

            // using dyanmics
            dynamic name = "Meet";
            name = 10; // here name will change its type to int by DLR which sits over CLR
        }
    }
}
