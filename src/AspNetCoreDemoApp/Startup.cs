using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreDemoApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        private readonly ILogger _logger;

        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;
            Console.WriteLine($"env= {env}");

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true )
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()


                .Build();
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddCors()
                .AddJsonFormatters();

            _logger.LogInformation("Added ZZZZZZZZZZZZZZ to services");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            if (env.IsProduction())
            {
                Console.WriteLine("https");
                var options = new RewriteOptions()
                    .AddRedirectToHttpsPermanent();

                app.UseRewriter(options);
            }
            if (env.IsDevelopment())
            {
                Console.WriteLine("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                _logger.LogInformation("In Development environment");
            }
        }
    }
}