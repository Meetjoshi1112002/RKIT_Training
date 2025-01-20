/*
     * Interfaces:
     * 
     * They are made to build loosly coupled applicatoins
     * 
     * We reduce the coupling between two classes by putting an interface between them.
     * 
     * Eg: OrderProcessor needs order to process
     * 
     * But we dont need every propeties or method of it
     * 
     * So in OrderProcessor we dont pass ref of order but of interface that declared all necessary 
     *                  property or methods that OrderProcessor will need
     *                  This was Order class may undergo chages without modifiy OrderP(as long as infterface not change)
     *                  
     * One of the common misconceptions about interfaces is that they are used to implement multiple inheritance in C#.
     * 
     */

namespace Advance_API._8_TypeOfClasses
{

    internal class InterfaceDemo
    {
    }
}
