using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Features of Data table

//In - Memory Representation: It stores data in memory as rows and columns.

//Independent of Database: Can be used independently or as part of a DataSet.

//Data Manipulation: Allows adding, updating, and deleting rows/columns programmatically.

//Filtering and Sorting: Supports filtering and sorting data using expressions.

namespace Collections.Basics
{
    internal class BasicDataTable
    {
        public static void display()
        {
            // Create a new DataTable
            DataTable table = new DataTable("SampleTable");

            // Add columns //can have primary key , forieng key(check it)
            // check delete triggers like on delete cascade ... 
            // explore methods like copy clone ..
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));

            Console.WriteLine("DataTable created successfully!");

            // Add rows to the DataTable direclty
            table.Rows.Add(1, "Alice", 25);
            table.Rows.Add(2, "Bob", 30);

            // Add Using DataRow
            DataRow newRow = table.NewRow();
            newRow["ID"] = 3;
            newRow["Name"] = "Charlie";
            newRow["Age"] = 35;
            table.Rows.Add(newRow);

            Console.WriteLine("Rows added successfully!");

            // Accessing the data
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}, Age: {row["Age"]}");
            }

            // Filter rows where Age > 25
            DataRow[] filteredRows = table.Select("Age > 25");
            foreach (DataRow row in filteredRows)
            {
                Console.WriteLine($"Filtered - Name: {row["Name"]}, Age: {row["Age"]}");
            }


        }
    }
}
