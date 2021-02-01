using APIGateway.AcceptanceTest.APIs;
using Microsoft.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    { 
        public async Task<string> Return_finance_appsettingsurls_async()
        {
            var test_url = new Finance();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}test_response/finance/get/baseurls");
            return response; 
        }

        public async Task<string> Return_finance_appsettings_connectionstrings_async()
        {
            var test_url = new Finance();
            var client = new HttpClient();
            var response = await client.GetStringAsync($"{test_url.Backend}test_response/finance/get/connectionstring");
            return response;
        }

        public async Task<bool> Access_finance_tables()
        {
            var test_url = new Finance();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/finance/get/connectionstring");
            string query = $"select * from fin_transaction";
            return Access_database_and_return_boolean(conn_str, query);
        }


        public async Task<bool> Make_a_request_that_will_return_true_for_finance()
        {
            var test_url = new Finance(); 
            var url = $"{test_url.DefaultGateway}bankgl/get/all/bankgl";
            return await Access_service_via_the_default_Gateway(url);
        } 

      

    }
}


