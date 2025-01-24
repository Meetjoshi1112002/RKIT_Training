using System;
using System.IO;

namespace Advance_API._9_FileSystem
{
    public class FileINFO
    {
        public static void sample()
        {
            string filePath = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9_FileSystem\\file1.txt";

            try
            {
                // Create a FileInfo object for the file "file1.txt"
                FileInfo fi = new FileInfo(filePath);

                // Check if the file exists before proceeding
                if (fi.Exists)
                {
                    // Display file properties
                    Console.WriteLine("File Exists: " + fi.Exists);
                    Console.WriteLine("Full Name: " + fi.FullName);
                    Console.WriteLine("Is Read-Only: " + fi.IsReadOnly);
                    Console.WriteLine("File Name: " + fi.Name);
                    Console.WriteLine("File Extension: " + fi.Extension);
                    Console.WriteLine("Creation Time: " + fi.CreationTime);
                    Console.WriteLine("Creation Time (UTC): " + fi.CreationTimeUtc);
                    Console.WriteLine("Directory: " + fi.Directory);
                    Console.WriteLine("Directory Name: " + fi.DirectoryName);
                    Console.WriteLine("Last Access Time: " + fi.LastAccessTime);
                    Console.WriteLine("Last Write Time: " + fi.LastWriteTime);
                    Console.WriteLine("File Size (Bytes): " + fi.Length);

                    // Rename the file
                    string newFileName = "renamed_example.txt";
                    fi.MoveTo(newFileName);
                    Console.WriteLine($"File renamed to: {newFileName}");

                    // Copy the file to a new location
                    string copyPath = "copied_example.txt";
                    fi.CopyTo(copyPath, overwrite: true);
                    Console.WriteLine($"File copied to: {copyPath}");

                    // Delete the file
                    fi.Delete();
                    Console.WriteLine("File deleted.");
                }
                else
                {
                    Console.WriteLine("File does not exist at the specified path: " + fi.FullName);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: The file was not found.");
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: Access to the file is denied.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: A file operation failed.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
