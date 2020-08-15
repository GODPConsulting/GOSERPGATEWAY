using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        readonly string MyAllowSpecificOrigin1 = "_myAllowSpecificOrigins1";
        readonly string MyAllowSpecificOrigin2 = "_myAllowSpecificOrigins2";
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
                options.AddPolicy(MyAllowSpecificOrigin1,
                builder =>
                {
                     builder.WithOrigins("http://godp.co.uk:500", "http://localhost:5200", "http://www.godp.co.uk:500", "http://localhost:4200")
                   .AllowAnyHeader()
                    .AllowAnyMethod(); 
                }); 
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseCors("_myAllowSpecificOrigins1"); //Default

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            await app.UseOcelot();

            app.UseDiscoveryClient();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
