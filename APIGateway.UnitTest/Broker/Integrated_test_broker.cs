using APIGateway.AcceptanceTest.Test_models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RESTFulSense.Clients;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using TollGates;
using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(x => { x.UseStartup<Startup>().UseTestServer(); });
            return builder;
        }
    }
    public partial class Integrated_test_broker
{
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient baseClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public Integrated_test_broker()
        { 
            _factory = new CustomWebApplicationFactory<Startup>();
            baseClient = _factory.CreateClient(); 
            apiFactoryClient = new RESTFulApiFactoryClient(baseClient); 
        }

        [Fact]
        public GlobalConfigurationBaseURLS Return_GlobalConfiguration()
        {
            var settings = File.ReadAllText("appsetting.json"); 
            var result = JsonConvert.DeserializeObject<AppSettings>(settings);
            if (result.GlobalConfiguration.Any())
            {
                var urls = new GlobalConfigurationBaseURLS
                {
                    DEFAULTGATEWAY = result.GlobalConfiguration.ToArray()[0].BaseUrl,
                    PURCHASE_PAYABLES_WEB = result.GlobalConfiguration.ToArray()[1].BaseUrl,
                    CREDIT_WEB = result.GlobalConfiguration.ToArray()[2].BaseUrl
                };
                return urls;
            }
            return new GlobalConfigurationBaseURLS();
        }
    }
}
    