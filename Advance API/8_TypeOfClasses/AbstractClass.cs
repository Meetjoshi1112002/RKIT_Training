using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._8_TypeOfClasses
{
    // Abstract class
    /*
     * Abstract modifier states that a class or a member misses implementation.
     * 
     * Abstract classes cannot be instantiated.
     * 
     * no instance of such class but can have a reference to child.
     * 
     * In a derived class, we need to override all abstract members of the base class, otherwise that derived class is going to be abstract too.
     * 
     * these cannot be sealed classes.
     * can inherit one class and one or more interfaces
     * 
     * abstract methods can't have private as access modifier.
         can have instance variables.
         can have constructors.
         can be use to provide a common definition for all child classes.
     * 
     */

    abstract class shape
    {
        public string name;

        public abstract void draw_shape();  // abstract method cannot have default implementation
    }

    class circle : shape
    {
        public circle()
        {
            name = "circle";
        }

        public override void draw_shape()
        {
            Console.WriteLine($"we draw the shape {name}");
        }
    }
}
