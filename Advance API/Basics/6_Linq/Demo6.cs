using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
 * LINQ thoery:
 * 
 * Give capability to query objects in C#
 * 
 * Help to query object in memory (collecitons), xml , db , ADO.net data sets
 * 
 * We can chain linq methods and we have two formats to write it
 * 
 * 1st  : Query operation syntax
 *          var result = 
 *              select b from books
 *              where b.Price > 100
 *              orderby b.Title 
 *              select b.Titile 
 *             
 * 2nd  : Linq extension method syntax 
 *          var resutlt = (Ienum implemented collection).Where (predicate <Func<T,bool>)
 *                                                      .OrderBy(predicate<Func(T,Tkey>)
 *                                                      .Select (predicate<Func(T,Tresult)
 *                                                      
 *                                                      we would more 2nd syatax more often
 *                                                      
 *  Important Mehtods:
 *  
 *  Single --> Howerver throws exception when item not found
 *  
 *  SingleOrDefault --> Same as single but not throw exception
 *  
 *  First 
 *  
 *  FirstOrDefault
 *  
 *  Last
 *  
 *  LastOrDefault
 *  
 *  Skip and Take --> used for pagination
 *  
 *  Count , Max , Min , Sum , average --> aggragate funcitns
 *  
 *  With linq we can do SQL in C# of in memory
 * 
 
 */

namespace Advance_API._6_Linq
{
    public class Demo6
    {
        public static void samp()
        {
            //new Demo6().QuerySyntax();
            new Demo6().ExtensionSyntax();
        }
    }
}
