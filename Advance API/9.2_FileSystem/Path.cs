using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_API._9_FileSystem
{
    public class PathDemo
    {

        public static void show()
        {
            string file_path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9_FileSystem\\DirectoryDemo.cs";

            Console.WriteLine(Path.GetDirectoryName(file_path));  // get the direcotory of the file

            Console.WriteLine(Path.GetFileName(file_path));  // get file name with extension

            Console.WriteLine(Path.GetFileNameWithoutExtension(file_path));  // get file name without extension

            Console.WriteLine(Path.GetExtension(file_path));  // get extension

        }
    }
}
