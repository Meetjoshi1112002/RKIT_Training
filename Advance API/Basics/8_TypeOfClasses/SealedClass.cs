using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._8_TypeOfClasses
{
    // sealed class
    /*
        -If applied to a class, prevents derivation from that class.
    
        -If applied to a method, prevents overriding of that method in a derived class.
    */
    sealed class SealedClass
    {
        int a = 5;
        public SealedClass()
        {
            Console.WriteLine("sealed class constructor.");
        }
    }
}
