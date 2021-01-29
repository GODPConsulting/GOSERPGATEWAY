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

        public async Task<Backend_response> Login_into_identity_severasync()
        {
            var test_url = new Identity_server();
            var client = new HttpClient();
            var loginrequest = new Login();
            var jsoncontent = JsonConvert.SerializeObject(loginrequest);
            var buffercontent = Encoding.UTF8.GetBytes(jsoncontent);
            var bytecontent = new ByteArrayContent(buffercontent);
            bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{test_url.Backend}api/v1/identity/login", bytecontent);
            var respnse_strings_value = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Backend_response>(respnse_strings_value);
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

    }
}


