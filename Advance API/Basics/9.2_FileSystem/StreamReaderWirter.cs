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
