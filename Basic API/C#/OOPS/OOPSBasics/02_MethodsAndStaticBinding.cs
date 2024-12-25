using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In C# (method signature) === (number , type and order of its parameter)

// overloading means same playing with signature (not return type) and same name 

// note mehtod overloading is static binding so occurs at compile time only 

// concept of type casting and ambiguity occrs (when mulitple perfect match)

// note add(int a,char b) add(char a, int b) will have ambiguity for add('a','a') 
// In short when multiple match exits on type cast


namespace OOPS.OOPSBasics
{
    internal class MethodsBasics
    {
        //rule 1: params arrtibuted paramter must be last 
        void operation(char op,params int[] args)
        {
            if (op == '+')
            {
                Console.WriteLine("The sum is " + (args[0] + args[1]));
            }
        }
        //rule 2: ref is like passing reference but dont use it
        void operation(ref int a ,ref int b)
        {
            a = a + b;
            b = 0;
        }

        //rule 3: out to get a opeation in local scope visible outside (dont use)
        void operation(out int ans, int a,int b)
        {
            ans = a + b;
        }

        public static void display()
        {
            MethodsBasics b = new MethodsBasics();
            int[] args = new int[] { 5, 6 };
            b.operation('+', args);
        }
    }
}
