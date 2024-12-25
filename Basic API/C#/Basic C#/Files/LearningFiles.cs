using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_API.Files
{
    internal class LearningFiles
    {
        public static void display()
        {
            // File , FIleInfo: -> provides methods for file operation s and are very similar
            // File provide static methods
            // FileInfo provides instance methods

            // Use fileInfo when more operations are needed as File undergo security check by OS everytime used

            // similary Direcetory and DirectoryInfo


            // File

            string path = "C:\\Users\\HEMANT\\Desktop\\RKIT\\New folder\\Basic C#\\Files\\source.txt";
            string dest = "C:\\Users\\HEMANT\\Desktop\\RKIT\\New folder\\Basic C#\\Files\\desti.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("Yes the file exits and Heres the content");

                Console.WriteLine(File.ReadAllText(path));
                File.Copy(path, "C:\\Users\\HEMANT\\Desktop\\RKIT\\New folder\\Basic C#\\Files\\destination.txt", true);
                // true means to overwrite if exites

                File.Delete(path); // delete current file
            }
            else
            {
                FileInfo fi = new FileInfo(path);
                using (StreamWriter w = fi.CreateText())
                {
                    w.WriteLine("This file is created here only and data is readed");
                }

                using (FileStream fs = fi.OpenWrite())
                using (StreamReader r = fi.OpenText())
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    string content = r.ReadToEnd();
              
                    Dictionary<char, int> mp = new Dictionary<char, int>()
                    {
                        { 'a', 0 },
                        { 'e', 0 },
                        { 'i', 0 },
                        { 'o', 0 },
                        { 'u', 0 },
                    };

                    foreach (char c in content)
                    {
                        char lowerC = char.ToLower(c); // Convert to lowercase
                        if (mp.ContainsKey(lowerC)) // Check if it's a vowel
                        {
                            mp[lowerC]++; // Increment count for the vowel
                        }
                    }
                    // Display the counts
                    foreach (var pair in mp)
                    {
                        Console.WriteLine($"Vowel '{pair.Key}': {pair.Value}");
                    }
                }
            }



        }
    }
}
