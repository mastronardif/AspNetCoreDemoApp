using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using AspNetCoreDemoApp.Services.Mail;


namespace AspNetCoreDemoApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddCors()
                .AddJsonFormatters();
            //_logger.LogInformation("Added ZZZZZZZZZZZZZZ to services");

            if ((Configuration["MailService"] != null) && string.Compare(Configuration["MailService"].ToUpper(), "CLOUD") == 0)
            {
                services.AddTransient<IMailService, CloudMailService>();
            }
            else
            {
                services.AddTransient<IMailService, LocalMailService>();
            }            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
                app.UseDeveloperExceptionPage();
                Console.WriteLine("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                //_logger.LogInformation("In Development environment");
            }
        }
    }
}