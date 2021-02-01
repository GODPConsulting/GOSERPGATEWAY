using APIGateway.AcceptanceTest.APIs;
using APIGateway.AcceptanceTest.Test_models.Response;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    {

    
        public async Task<string> Return_identity_appsettingsurls_async()
        {
            var test_url = new Identity_server();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}test_response/indentity_server/get/baseurls");
            return response; 
        }
         
        public async Task<string> Return_identity_appsettings_connectionstrings_async()
        {
            var test_url = new Identity_server();
            var client = new HttpClient();
            var response = await client.GetStringAsync($"{test_url.Backend}test_response/indentity_server/get/connectionstring");
            return response;
        }
 
         
        public async Task<bool> Return_identity_server_operatons_async()
        {
            var test_url = new Identity_server();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/indentity_server/get/connectionstring");
            return Read_operations_data(conn_str); 
        }

       

        private static bool Read_operations_data(string connectionString)
        {

            string queryString = "SELECT * FROM dbo.cor_operation;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.Read(); 
                }
            }
        }
         
        public async Task<bool> Make_a_request_that_will_return_true_for_identity_server()
        {
            var test_url = new Identity_server(); 
            var url = $"{test_url.DefaultGateway}admin/get/all/activityParents";
            return await Access_service_via_the_default_Gateway(url);
        }

    }
}


