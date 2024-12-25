using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Learnings:
//If thre is a parameterized construtor , then there must be a default one

//use this to travel between multiple construtors : ---> useful for memeory allocations of collections fields of object

// Type of constructors: default , parameerized , copy , static , private

//: static : only called once for all object ,
//           cannot have parameters or any access modifers or cannot be overloaded (private by default)
              

namespace OOPS.OOPSBasics
{
    internal class Pilot
    {
        string name;
        List<string> flights;
        static int pilotCount;
        static int planesOccupied;

        static Pilot()
        {
            Console.WriteLine("Static constructor invoked only once for entire class");
            pilotCount = 0;
            planesOccupied = 0;
        }
        public Pilot()
        {
            flights = new List<string>();
            pilotCount++;
            planesOccupied++;
            Console.WriteLine("Default one");
        }

        public Pilot(string name):
            this() 
        {
            Console.WriteLine("Parameter cons");
            this.name = name;
        }

        public Pilot(Pilot p):this()
        {
            Console.WriteLine("Copy construtcor");
            this.name = p.name;
        }
    }
    internal class BasicOfClassObject
    {
        public static void display()
        {
            Pilot p = new Pilot("Meet Joshi");
            Pilot p2 = new Pilot(p);
        }
    }
}
