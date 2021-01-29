using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting; 
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Steeltoe.Discovery.Client;

namespace TollGates
{
    public class Startup
    {
        public IConfiguration Configuration { get; } 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddOcelot(Configuration).AddConsul();
             services.AddDiscoveryClient(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
                }); 
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy"); 

            if (env.IsDevelopment()) 
                app.UseDeveloperExceptionPage(); 
            else 
                app.UseHsts(); 

            await app.UseOcelot();
            app.UseRouting();
            app.UseStaticFiles();  
        }
    }
}
