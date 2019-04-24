using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace AspNetCoreDemoApp
{
    public class Program
    {
        //public static void Main(string[] args) =>
          //  CreateWebHostBuilder(args).Build().Run();

        public static void Main(string[] args)
        {
            //var host = 
            CreateWebHostBuilder(args).Build()
            //var logger = host.Services.GetRequiredService() .GetRequiredService<ILogger<Program>>();
            //logger.LogInformation("Seeded the database.");
            //host
            .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
}
}