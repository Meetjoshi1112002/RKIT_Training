namespace Collections.Basics
{
    internal class BasicsOfCollections
    {
        
        public static void display()
        {
            // Understand Generic and non generic colleciton

            //1st Generic colleciton
            //    we define the data it store before using it.
            //    found in System.Collections.Generic
            //    Advantage: type safe
            //               No boxing and unboxing 
            //               Code Resuable
            int val = 5
            Object jo = (Object)val;

            int johs = (int)jo;
            //2nd Non Generic collection:
            //    found in System.Collections
            //    They store any data type
            //    This arises the concept of storing in refernces --> 
            //    so to store value type data , it has overhead of boxing and unboxing
            //    Disadvantage : highly error prone


            // Conclusion : Use Generic collections !





            Console.WriteLine("Fundamtal Cleared of Generic vs Non Generic");


        }
    }
}


//public static void fileOperation()
//{
//    string filePath = "./sample.txt";
//    try
//    {
//        // Step 1: Read the file contents
//        string fileContent = File.ReadAllText(filePath);

//        // Step 2: Initialize a dictionary to hold the vowel counts
//        Dictionary<char, int> vowelCounts = new Dictionary<char, int>
//    {
//        {'a', 0},
//        {'e', 0},
//        {'i', 0},
//        {'o', 0},
//        {'u', 0}
//    };

//        // Step 3: Count the vowels in the file content
//        foreach (char c in fileContent.ToLower())
//        {
//            if (vowelCounts.ContainsKey(c))
//            {
//                vowelCounts[c]++;
//            }
//        }

//        // Step 4: Prepare the result to be written at the end of the file
//        string result = "\nVowel Counts:\n";
//        foreach (var pair in vowelCounts)
//        {
//            result += $"{pair.Key}: {pair.Value}\n";
//        }

//        // Step 5: Append the result to the file
//        File.AppendAllText(filePath, result);

//        // Step 6: Display a success message
//        Console.WriteLine("Vowel counts have been written to the file successfully.");
//    }
//    catch (Exception ex)
//    {
//        // Handle any errors
//        Console.WriteLine($"An error occurred: {ex.Message}");
//    }
//}