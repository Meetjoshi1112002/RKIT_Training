/*
 * 
 * partial class
    
     in partial class, code can be written in two or more files.

     all parts of partial class should have same access modifier.

     all definitions must be in the same assembly.

     if any part of partial class is sealed or abstract, then all parts bcome that.

     any inheritance on any part is applied to all parts automatically

     can be used if need to work parallely with same class but many members in it.
    
*/

namespace Advance_API._8_TypeOfClasses
{
    public partial class Employee
    {
        public int part1 = 3;
        public Employee()
        {
            Console.WriteLine("Partial class constructor.");
            part2 = 7;
        }
    }

    public partial class Employee
    {
        public int part2 = 5;
    }
}
