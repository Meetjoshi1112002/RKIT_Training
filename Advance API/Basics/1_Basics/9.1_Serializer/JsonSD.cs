using System.Text.Json;
using System.Text.Json.Serialization;


/*
 * 
 * Serialzation: useful for save data to a file, send it over a network, or store it in a database in a format that other systems can understand.
 * 
 * System.Text.Json: A lightweight and fast library for JSON serialization and deserialization 
 * 
 * Newtonsoft.Json (Json.NET): A popular third-party library that has been widely used in .NET applications. It offers advanced features and customization.
 * 
 * Your C# class must have properties that match the structure of the JSON data (case-insensitive by default in System.Text.Json).
 * 
 * Handling Nested JSON:
                        If your JSON contains nested objects, your C# class should include properties for those nested types.

 * If the JSON contains arrays, use List<T> or T[] in your class.
 * 
 * You can customize the behavior using JsonSerializerOptions.
 * 
 * Always handle exceptions like JsonException to catch issues like invalid JSON
 */
namespace Advance_API._9._1_Serializer
{
    public class Employee
    {
        [JsonPropertyName("Name")]
        public string P01F01 { get; set; }

        [JsonPropertyName("ID")]
        public int P02F02 {get; set; }
    }
    public static class JsonSD
    {
        public static void show()
        {
            List<Employee> emps = new()
            {
                new Employee { P01F01 = "Meet joshi", P02F02 = 425 },
                new Employee { P01F01 = "Navneet K", P02F02 = 422 },
                new Employee { P01F01 = "Rohanshu", P02F02 = 420 }
            };

            var opiton = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string str = JsonSerializer.Serialize<List<Employee>>(emps,opiton);

            using(FileStream fs = new FileStream("C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9.1_Serializer\\file.txt",FileMode.OpenOrCreate,FileAccess.Write))
            using (StreamWriter fw = new StreamWriter(fs))
            {
                fw.WriteLine(str);
            }


            // Deserialization
            using (FileStream fs = new FileStream("C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9.1_Serializer\\file.txt", FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter fw = new StreamWriter(fs))
            {
                fw.WriteLine(str);
            }

            string jsonContent = File.ReadAllText("C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Advance API\\9.1_Serializer\\file.txt");
            emps = JsonSerializer.Deserialize<List<Employee>>(jsonContent) ?? new List<Employee>();

            foreach(var emp in emps)
            {
                Console.WriteLine(emp.P01F01);
            }

        }
    }
}
