using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._4_ExtensationMethods
{
    public static class MeetExtension
    {
        public static void DisplayDetail(this Meet m)
        {
            Console.WriteLine($"My name is Meet and my hobby is {m.Hobby} and role is {m.Role}. Thank you ... ");
        }
    }
}
