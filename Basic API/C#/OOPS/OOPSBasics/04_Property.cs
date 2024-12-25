using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.OOPSBasics
{
    // Why propery:?
                //Provides encapsulation
                //Future proofing for modification (only update get and set)
                //Ensure validations 
                // read only or write only access possible (if not get and write only and vice versa)

                    
            
    internal class PropertyBasic
    {
        private string name;

        public string Name
        {
            get // ensure private field name is always access in upper casing
            {
                return name.ToUpper();
            }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new Exception("Cannot be null");
                name = value;
            }
        }

        // auto implemented 
        public string college { get; set; }

        public static void display()
        {
            PropertyBasic p = new PropertyBasic();
            p.Name = "Meet joshi";
            Console.WriteLine($"Name: {p.Name}"); // Output the name in uppercase
        }

    }
}
