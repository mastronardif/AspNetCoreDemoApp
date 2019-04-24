using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace AspNetCoreDemoApp
{
    public class Program
    {
        //public static void Main(string[] args) =>
          //  CreateWebHostBuilder(args).Build().Run();


        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        static Serilog.Core.Logger Log = null;
        static int nsecs = 1000;
        public static int Main(string[] args)
        {
 // Create the logger
 
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.development.json")
                    .Build();

            Log = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)   
                .Enrich.FromLogContext()

                .CreateLogger(); 

                Log.Verbose("VVVVVVVV Verbose AspNet.Core");
                
                Console.WriteLine($"'waiting {nsecs} milli secs."); Task.Delay(nsecs).Wait(); // Wait 2 seconds with blocking
                Log.Debug(  "DDDDDDDD Debug  AspNet.Core");
                Console.WriteLine($"'waiting {nsecs} milli secs."); Task.Delay(nsecs).Wait(); // Wait 2 seconds with blocking
                Log.Information(  "IIIIIIII Information  AspNet.Core");
                Console.WriteLine($"'waiting {nsecs} milli secs."); Task.Delay(nsecs).Wait(); // Wait 2 seconds with blocking                
                Log.Warning("WWWWWWWW Warning  AspNet.Core");
                Log.Fatal(  "FFFFFFFF Fatal terminated unexpectedly  AspNet.Core");
                Log.Error(  "EEEEEEEE Error  AspNet.Core");
                Log.Verbose("VVVVVVVV Error  AspNet.Core");


                Log.Information("Host IIIIIIIIIIII AspNet.Core");
                nsecs  =6000;
                Console.WriteLine($"'waiting {nsecs} milli secs. The end is near."); Task.Delay(nsecs).Wait(); // Wait 2 seconds with blocking                

            try
            {
                Log.Information("Starting web host  AspNet.Core");
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly  AspNet.Core");
                return 1;
            }
            finally
            {
                Console.WriteLine();
                Log.Information("finally finally finally!!!!!!!!!!!!!!  AspNet.Core");
                //Log.CloseAndFlush();
            }
        }


 public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
 .UseSerilog(); // <-- Add this line
       public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
	    .UseStartup<Startup>()
            .UseSerilog() // <-- Add this line
            .Build();

}
}