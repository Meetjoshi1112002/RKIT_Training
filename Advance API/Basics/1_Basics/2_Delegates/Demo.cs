using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


/*
 * Delegates :
 * 
 * A object that knows how to call a method or group of method
 * 
 * A pointer to function
 * 
 * Usage : used in making framework
 * 
 * So basically Delegate is like creating a funciton or group of funciton same prototype pointer
 * 
 * System.Func is system deligate --> has return as first paramter
 * 
 * System.Action is also system deligate --> has void return
 * 
 */

namespace Advance_API._2_Delegates
{
    public class Photo { }
    public class PhotoProcesser
    {
        public delegate void PhotoProcess(Photo p); //  --> here we created a deltegate called PhotoProcess
                                                    //  --> All the proces that we want on photo , we will give that to delegates
        public void ProcessByCustomDeligates(Photo p, PhotoProcess ps)
        {
            ps(p);

            Action<Photo> photo_d;

            photo_d = (Photo p) => { };

            photo_d += (Photo) => { };
            photo_d(p);
        }

        public void ProcessBySystemDeligate(Photo p, System.Action<Photo> pr)
        {
            pr(p);
        }
    }
    public static class Demo
    {
        public static void display()
        {
            PhotoProcesser PPro = new PhotoProcesser();

            // custom deligate
            PhotoProcesser.PhotoProcess MethodsToApply = (Photo p) => { Console.WriteLine("Method 1"); };
            MethodsToApply += (Photo p) => { Console.WriteLine("Method 2"); };
            MethodsToApply += (Photo p) => { Console.WriteLine("Method 3"); };
            MethodsToApply += (Photo p) => { Console.WriteLine("Method 4"); };

            // using system deligate
            Action<Photo> filters = (Photo p) => { Console.WriteLine("F- Method 1"); };
            filters += (Photo p) => { Console.WriteLine("F-Method 2"); };

            PPro.ProcessByCustomDeligates(new Photo(), MethodsToApply);
            PPro.ProcessBySystemDeligate(new Photo(), filters);
        }
    }
}
