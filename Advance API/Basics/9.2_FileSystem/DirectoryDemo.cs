using System;
using System.IO;  // Make sure to include this for Directory and FileSystem operations

namespace Advance_API._9_FileSystem
{
    public static class DirectoryDemo
    {
        public static void DirectoryDemo1()
        {
            // Get the current working directory
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("Current Directory: " + path);

            // --> Check if the directory exists; if not, create it
            string newDirectoryPath = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9_FileSystem\\newDemoDirectory";
            if (!Directory.Exists(newDirectoryPath))  // Check if the directory exists
            {
                // Create a new directory at the specified path
                Directory.CreateDirectory(newDirectoryPath);
                Console.WriteLine("Yes, the directory now exists.");
            }

            // --> Get all subdirectories matching a pattern
            string[] dirs = Directory.GetDirectories("C:\\Users\\meet.j\\Desktop\\RKIT_Training", "*patter*");
            // Uncomment the below line to display the directories
            // foreach (string dir in dirs) Console.WriteLine(dir);

            // --> Get all .cs files in a directory
            string[] files = Directory.GetFiles("C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API", "*.cs");
            Console.WriteLine("List of C# files:");
            foreach (string file in files)
            {
                Console.WriteLine(file);  // Print each .cs file found
            }

            // --> Get both files and subdirectories in a specified directory
            string[] entries = Directory.GetFileSystemEntries("C:\\MyFolderPath");
            // Display files and subdirectories
            // foreach (string entry in entries) Console.WriteLine(entry);

            // --> Get the parent directory of a specific path
            string pathToParent = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9_FileSystem\\newDemoDirectory";
            DirectoryInfo parent = Directory.GetParent(pathToParent) ?? new DirectoryInfo("C:\\Users\\meet.j\\Desktop\\RKIT_Training");
            Console.WriteLine("Parent Directory: " + parent.FullName);

            // --> Move a directory from one location to another
            string sourceDir = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9_FileSystem\\newDemoDirectory";
            string targetDir = "C:\\Users\\meet.j\\Desktop\\Homee";
            Directory.Move(sourceDir, targetDir);  // Move the directory

            // --> Delete a directory (ensure it's empty before deletion)
            string dirToDelete = "C:\\Users\\meet.j\\Desktop\\Homee\\oldDirectory";
            if (Directory.Exists(dirToDelete))
            {
                Directory.Delete(dirToDelete);
                Console.WriteLine("Directory deleted.");
            }
        }
    }
}
