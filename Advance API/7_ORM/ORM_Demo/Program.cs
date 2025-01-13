using ServiceStack.OrmLite;
using System;

string urlToDB = "Server=localhost;database=orm_demo_mj;User=Admin;Password=gs@123";

// Create the OrmLite connection factory
var fac = new OrmLiteConnectionFactory(urlToDB, MySqlDialect.Provider);

try
{
    // Attempt to create and open a connection
    using (var db = fac.CreateDbConnection())
    {
        db.Open();
        Console.WriteLine("Connection to the database was successful.");
    }
}
catch (Exception ex)
{
    // If there's an error, it will be caught here
    Console.WriteLine($"Error connecting to the database: {ex.Message}");
}
