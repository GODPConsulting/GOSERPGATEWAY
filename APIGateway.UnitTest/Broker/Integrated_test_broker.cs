using APIGateway.AcceptanceTest.APIs;
using APIGateway.AcceptanceTest.Test_models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RESTFulSense.Clients;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TollGates;

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

        public static bool Access_database_and_return_boolean(string connString, string query)
        { 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    catch (System.Exception)
                    {
                        conn.Close();
                        return false;
                    }

                }
            }
        }

        public async Task<bool> Access_service_via_the_default_Gateway(string Url)
        {
            var client = new HttpClient();

            await Authenticate_async(client);

            var response = await client.GetAsync(Url);

            var response_as_strings = await response.Content.ReadAsStringAsync();

            var deserialized_response = JsonConvert.DeserializeObject<Backend_response>(response_as_strings);

            return deserialized_response.Status.IsSuccessful;
        }

        public async Task<Backend_response> Login_into_service_async(string url)
        {
            var testurl = new General_urls();
            var client = new HttpClient();

            var loginrequest = new Login();
            var jsoncontent = JsonConvert.SerializeObject(loginrequest);
            var buffercontent = Encoding.UTF8.GetBytes(jsoncontent);
            var bytecontent = new ByteArrayContent(buffercontent);

            bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{testurl.DefaultGateway}{url}", bytecontent);
            var respnse_strings_value = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Backend_response>(respnse_strings_value);
        }
    }
}
    