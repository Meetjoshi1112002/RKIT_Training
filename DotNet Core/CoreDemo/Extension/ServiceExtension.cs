using CoreDemo.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CoreDemo.Extension
{
    public static class ServiceExtension
    {
        public static void AddServicesToContainer(this IServiceCollection services)
        {
            // Now we register our interface and class implemeting that interface to the containser
            services.AddSingleton<IUserRepo, UserRepo>(); // we registerd this as singleton 
                                                          // so only one instance of the object created by dot net and pass interface reference to all demanding it
                                                          // (generally given to constructor of controller demainding it)
            //services.AddScoped<IUserRepo, UserRepo>();
            //services.AddScoped<IUserRepo,TestRepo>();

            // Try overwrite the current if repearing Interface for other class

            // simple add will overwrite the pervious 
        }
    }
}
