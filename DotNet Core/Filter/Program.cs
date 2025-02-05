using Filter;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new WebApplicationBuilder instance
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Create a new instance of the Startup class, passing the application's configuration to it.
        Startup startup = new Startup(builder.Configuration);

        // Configuring Services
        startup.ConfigureServices(builder.Services);

        // Build the web application using the configured services
        WebApplication app = builder.Build();

        // Configure the application and its environment
        startup.Configure(app, builder.Environment);

        // Run the application
        app.Run();
    }
}