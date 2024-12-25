using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Basics
{
    public class StackBasics
    {
        public static void display()
        {
            // can store null as refernce value type
            int[] arr = new int[2] { 2, 2 };
            Stack<int> stack = new Stack<int>(arr);
            stack.Push(3);
            stack.Push(2);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine(stack.Pop()); // returns and remove the top element

            Console.WriteLine(stack.Count); //reutnrs the count

            Console.WriteLine(stack.Peek()); // returns the top but not remove

            Console.WriteLine(stack.Contains(4)); //O(n)
            stack.Clear();

        }
    }
}
