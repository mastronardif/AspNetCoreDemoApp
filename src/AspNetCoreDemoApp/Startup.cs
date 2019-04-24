using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AspNetCoreDemoApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        //private readonly ILogger _logger;
        //private Serilog.Core.Logger Log { get; set; }
        // public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        // {
        //     _logger = logger;
        //     Console.WriteLine($"env= {env}");

        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(env.ContentRootPath)
        //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true )
        //         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //         .AddEnvironmentVariables()


        //         .Build();
        // }

        public Startup(IConfiguration configuration)
        {
             // Init Serilog configuration
            //Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

    
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddCors()
                .AddJsonFormatters();

            //_logger.LogInformation("Added ZZZZZZZZZZZZZZ to services");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
                Console.WriteLine("https");
                var options = new RewriteOptions()
                    .AddRedirectToHttpsPermanent();

                app.UseRewriter(options);
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Console.WriteLine("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                //_logger.LogInformation("In Development environment");
            }
         
            app
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseCors(builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                )
                .UseMvcWithDefaultRoute();
        }
    }
}