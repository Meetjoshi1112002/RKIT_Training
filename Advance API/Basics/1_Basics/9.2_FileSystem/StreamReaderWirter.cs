/*
 * Lowest level : FileStream as its is one who read and wirte from file in binary format
 * 
 * 
 * 
 * 
 * Read Data:
 * 
 * File --> FileStream --> StreamReader --> Application
 * 
 * Write Data:
 * 
 * Application --> StreamWriter --> FileStream --> File
 * 
 * ---------------------------------------------------------------
 *              
 */


namespace Advance_API._9_FileSystem
{
    public static class  StreamReaderWirter
    {
        public static void display()
        {
            string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9.2_FileSystem\\sample.txt";

            using(FileStream fs = new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("My name is Meet Joshi");
                sw.WriteLine("My name is Meet Joshi");
                sw.WriteLine("My name is Meet Joshi");
            }

            string content = "";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                content += sr.ReadLine();
                content += sr.ReadLine();
                content += sr.ReadLine();   // or content += sr.ReadToEnd()
                Console.WriteLine(content);
            }

        }
    }
}
