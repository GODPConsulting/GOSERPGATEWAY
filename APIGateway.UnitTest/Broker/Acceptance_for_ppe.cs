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
        public async Task<string> Return_PPE_appsettingsurls_async()
        {
            var test_url = new PPE();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}test_response/PPE/get/baseurls");
            return response; 
        }

        public async Task<string> Return_PPE_appsettings_connectionstrings_async()
        {
            var test_url = new PPE();
            var client = new HttpClient();
            var response = await client.GetStringAsync($"{test_url.Backend}test_response/PPE/get/connectionstring");
            return response;
        }

        public async Task<bool> Access_PPE_tables()
        {
            var test_url = new PPE();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/PPE/get/connectionstring");
            return Check_if_table_exist_PPE(conn_str);
        }

        public static bool Check_if_table_exist_PPE(string connString)
        {
            string query = "select * from ppe_assetclassification";
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


        public async Task<bool> Make_a_request_that_will_return_true_for_PPE()
        {
            
            var test_url = new PPE();  
            var url = $"{test_url.DefaultGateway}addition/get/all/addition";
            return await Access_service_via_the_default_Gateway(url);
        }

    }
}


