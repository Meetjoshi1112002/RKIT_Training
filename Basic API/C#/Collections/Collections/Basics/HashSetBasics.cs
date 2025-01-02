using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Basics
{
    internal class HashSetBasics
    {
        public static bool predicate(int a)
        {
            //if (a == 1)
            //    return true;
            //else return false;
            return a ;
        }
        public static void display()
        {
            HashSet<int> st = new HashSet<int>();

            // Theroy of HashSet

            // interanl working: (all occur in constant time)
            // create a hashCode for a element -->store it in bucket corresponding to that hash code
            // findHash of ele --> hashCode % bucketCount --> bucket found --> ele already there then ignore else add !


            st.Add(1);
            st.Add(2);
            st.Add(3);
            st.Add(1);
            Console.WriteLine(st.Contains(1));
            //Console.WriteLine(st[0]); --> not allwoed

            // other important 
            st.Remove(1);
            st.RemoveWhere(predicate); // remove all  1
            st.Clear();

            //setOperations: h1.UnionWith(h2) ...IntersectWith

        }
    }
}
