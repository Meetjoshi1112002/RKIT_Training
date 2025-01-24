using ORM_Demo.Data_Access.Reporitory;
using ORM_Demo.Models;
using ORM_Demo.Models.DTO;
using ORM_Demo.Models.Enum;

try
{
    ServiceProvider serv = new ServiceProvider();


    var ojb = new AdminDTO {Id = 7, Name = "RBBC", Role = AdminRole.SuperAdmin };

    serv.UpdateAdmin(ojb, "dssds");

    serv.DeleteAdmin(7);

    Response data = serv.GetAll();
        foreach (AdminDTO item in data.Data)
        Console.WriteLine( item.Name + " "+item.Role+" "+item.Id);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}