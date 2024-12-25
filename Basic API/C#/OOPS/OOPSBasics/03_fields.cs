using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.OOPSBasics
{
    internal class BasicOfFields
    {
        readonly List<int> data; // initialize here or in construtor , then cannot be changed
        public BasicOfFields()
        {
            data = new List<int>(); // or in construtor 
            // now data cannot be re initiazed
        }
        public void smap()
        {
            //data = new List<int> { 0 }; //prevents this 
        }
    }
}
