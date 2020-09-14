using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MediatR;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Steeltoe.Discovery.Client;

namespace TollGates
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigin1 = "_myAllowSpecificOrigins1"; 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        { 
            

            services.AddOcelot(Configuration).AddConsul();
            // services.AddDiscoveryClient(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigin1,
                builder =>
                {
                     builder.WithOrigins(
                         "http://godp.co.uk:500", 
                         "http://localhost:5200", 
                         "http://www.godp.co.uk:500",
                         "http://localhost:4200", 
                         "http://godp.co.uk:550/", 
                         "http://godp.co.uk:650/",
                         "http://localhost:8100" )
                   .AllowAnyHeader()
                    .AllowAnyMethod(); 
                }); 
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseCors("_myAllowSpecificOrigins1");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            await app.UseOcelot();
            app.UseRouting();
            app.UseStaticFiles();
           // app.UseDiscoveryClient(); 
        }
    }
}
