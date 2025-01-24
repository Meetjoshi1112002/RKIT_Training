using CRUD_Demo.Controller;
using CRUD_Demo.Models.DTO;
using CRUD_Demo.Models;



#region Adding a New Employee
Response addEmployeeResponse = ApiController.AddEmployee(new DTOEMP01
{
    P01F01 = 3,  // ID is 0 for new employee, auto-increment will be used
    P01F02 = "RB",
    P01F03 = "meet.joshi@example.com",
    P01F04 = "password123"
});

Console.WriteLine(addEmployeeResponse.Message);
#endregion

#region Updating an Existing Employee
Response updateEmployeeResponse = ApiController.UpdateEmployee(new DTOEMP01
{
    P01F01 = 2,  // Existing employee ID
    P01F02 = "Meet Joshi Updated",
    P01F03 = "meet.joshi.updated@example.com",
    P01F04 = "newpassword123"
});

Console.WriteLine(updateEmployeeResponse.Message);
#endregion

#region Deleting an Employee
Response deleteEmployeeResponse = ApiController.DeleteEmployee(1);  // Deleting employee with ID 2

Console.WriteLine(deleteEmployeeResponse.Message);
#endregion

#region Getting a Single Employee by ID
Response getEmployeeByIdResponse = ApiController.GetEmployeeById(2);  // Fetching employee with ID 2

if (!getEmployeeByIdResponse.ErrorStatus)
{
    var employee = (ReadDTOEMP01)getEmployeeByIdResponse.data;
    Console.WriteLine($"Employee found: {employee.P01F01} - {employee.P01F02} - {employee.P01F03} - {employee.P01F04}");
}
else
{
    Console.WriteLine($"Error: {getEmployeeByIdResponse.Message}");
}
#endregion

#region Getting All Employees
Response getAllEmployeesResponse = ApiController.GetAllEmployees();
if (!getAllEmployeesResponse.ErrorStatus)
{
    var employees = (List<ReadDTOEMP01>)getAllEmployeesResponse.data;
    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.P01F01} - {employee.P01F02} - {employee.P01F03} - {employee.P01F04}");
    }
}
else
{
    Console.WriteLine($"Error: {getAllEmployeesResponse.Message}");
}
#endregion