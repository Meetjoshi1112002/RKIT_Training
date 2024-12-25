using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Basics
{
    // applied to int type only
    public class MyList : Collection<int>
    {
        //Add method internally calls InsertItem.
        protected override void InsertItem(int index, int item)
        {
            int squaredValue = item * item;
            base.InsertItem(index, squaredValue);
        }
    }
    public class CollectionClass
    {
        public static void display()
        {
            // Colleciton class : (Customizable)
            // very similar to List (while List is sealed)
            // Only this is when you need some custom behaviour or more control over list then use this !
            // Defined in System.Collections.ObjectModel namespace.

            MyList c = new MyList();
            c.Add(1);
            c.Add(2);

            foreach (int i in c) {
                Console.WriteLine(i);
            }

            int[] arr = new int[] { 1, 2 }; // can be list as well
            Collection<int> c2 = new Collection<int>(arr);
            Console.WriteLine("Normal use of collection");
            foreach (int i in c2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
