using CoreDemo;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Use Startup class for app configuration
            });
}
/*
    #region Notes
Key Actions:
Host.CreateDefaultBuilder:
Sets up the hosting environment (Kestrel server, IIS integration).
Loads configuration(appsettings.json, launchSettings.json, etc.).
Configures logging.
webBuilder.UseStartup<Startup>():
Tells the host to use the Startup class for configuring the application.

    #endregion
 */