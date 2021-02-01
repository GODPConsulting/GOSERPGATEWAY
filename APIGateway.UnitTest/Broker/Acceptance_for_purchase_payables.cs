using APIGateway.AcceptanceTest.APIs;
using APIGateway.AcceptanceTest.Test_models.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    { 
        public async Task<string> Return_purchase_payables_appsettingsurls_async()
        {
            var test_url = new Purchase_and_payable();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}test_response/purchase_payables/get/baseurls");
            return response; 
        }

        public async Task<string> Return_purchase_payables_appsettings_connectionstrings_async()
        {
            var test_url = new Purchase_and_payable();
            var client = new HttpClient();
            var response = await client.GetStringAsync($"{test_url.Backend}test_response/purchase_payables/get/connectionstring");
            return response;
        } 
         
        public async Task<bool> Access_purchase_payables_tables()
        {
            var test_url = new Purchase_and_payable();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/purchase_payables/get/connectionstring");
            var query = "select * from cor_paymentterms";
            return Access_database_and_return_boolean(conn_str, query);
        }

        public async Task<bool> Make_a_request_that_will_return_true_for_purchase_payables()
        {

            var test_url = new PPE();
            var url = $"{test_url.DefaultGateway}addition​/get​/all​/addition";
            return await Access_service_via_the_default_Gateway(url);
        }

    }
}


