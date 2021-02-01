using APIGateway.AcceptanceTest.APIs;
using APIGateway.AcceptanceTest.Test_models.Response;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    { 
        public async Task<string> Return_report_appsettingsurls_async()
        {
            var test_url = new Report();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}testresponsereport/get/baseurls");
            return response; 
        } 
    }
}


