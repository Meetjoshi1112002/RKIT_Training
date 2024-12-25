using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Basics
{
    internal class QueueBasics
    {
        public static void display()
        {
            //The Queue<T> class in the.NET Framework uses a growth factor of 2.
            //This means that whenever the queue's capacity is exceeded, its size is doubled.
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(0); // adds element in queue
            queue.Enqueue(1);
            queue.Enqueue(2);

            Console.WriteLine(queue.Dequeue()); //remvoes and return ele in the  beginig

            Console.WriteLine(queue.Peek()); // returns but not remove ele in beg

            Console.WriteLine(queue.Contains(1)); //O(1)

            queue.Clear();

        }
    }
}
