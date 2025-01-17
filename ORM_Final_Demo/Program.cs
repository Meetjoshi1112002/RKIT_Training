using ORM_Final_Demo.Controller;
using ORM_Final_Demo.Models.DTO;

try
{
    Console.WriteLine("=== Employee Management System ===");

    // Add a new employee
    ApiClass.CreateEmployee(new DTOEMP01
    {
        P01F01 = 4,
        P01F02 = "Keyur sir",
        P01F03 = new DateTime(2003, 11, 1),
        P01F04 = "RKIT"
    });


    // Update the employee
    ApiClass.UpdateEmployee(new DTOEMP01
    {
        P01F01 = 2,
        P01F02 = "Rohashu B",
        P01F03 = new DateTime(2004, 11, 1),
        P01F04 = "Jay Durga Maa"
    });

    // Get all employees

    List<ReadDTOEMP01> employees = ApiClass.GetAll();

    foreach (var emp in employees)
    {
        Console.WriteLine($"ID: {emp.P01F01}, Name: {emp.P01F02}, Age: {emp.P01F05}");
    }
}
catch(Exception e)
{
    Console.WriteLine("Program failed as " + e.Message);
}