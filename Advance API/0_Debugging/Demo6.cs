using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Short-cuts
 *              F-9 : For breakpoint insertion
 *              F-5 : Run in debug mode
 *              F-10: For next line execution/ Step Over from a method
 *              F-11: Step into a method
 *              shift + F-11 : Step out of mehtod
 *              Shift + F-5  : Stop debug mode
 *              
 *              Yellow pointer to go back to any previous line in debug mode
 *              
 *              Hover over any variable to see its value in debug mode
 *              
 *              Watch Window : To observe the value of variable and not need to hover to see value
 *              
 *              locals , auto : TO keep track of variable values 
 *              
 *              autos : keep track of all kind of varibale possible :like a[i] if loop there
 *               
                Debug points - Breakpoints are markers in the code to pause execution of program during debugging.
                It allows us to inspect state of application at points to help fix issues.

                Types of breakpoints:
                1) Simple - stops execution whenever code hits that line.
                2) Conditional - stops only if specified condition is true.
                3) Hit count - stops execution after specified amount of hits.
                4) Tracepoint - outputs custom message to output window rather than pausing execution.
                5) Data - pauses when a variable field/property value changes.
        

*/

namespace Advance_API._0_Debugging
{
    public static class Demo0
    {
        public static int FindSmall(List<int> ls)
        {
            int min = ls[0];
            bool name = true;

            foreach (int i in ls)
            {
                if(i < min)
                {
                    min = i;
                }
            }

            return min;
        }
        public static void dis()
        {
            int samp = 10;

            //List<int> num = new List<int>() { 1,2,3,4,5};

            //int s = FindSmall(num);
            #region demo
                #if DEBUG
                            Console.WriteLine("Debug mode is ON.");
                #else
                            Console.WriteLine("Release mode is ON.");  // build -> configuration manager
                #endif

            Console.WriteLine("Program is running.");
            #endregion

        }
    }
}
