using APIGateway.AcceptanceTest.APIs;
using Microsoft.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    { 
        public async Task<string> Return_Treasury_appsettingsurls_async()
        {
            var test_url = new Treasury();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}test_response/treasury/get/baseurls");
            return response; 
        }

        public async Task<string> Return_Treasury_appsettings_connectionstrings_async()
        {
            var test_url = new Treasury();
            var client = new HttpClient();
            var response = await client.GetStringAsync($"{test_url.Backend}test_response/treasury/get/connectionstring");
            return response;
        }

        public async Task<bool> Access_Treasury_tables()
        {
            var test_url = new Treasury();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/treasury/get/connectionstring");
            return Check_if_table_exist_Treasury(conn_str);
        }

        public static bool Check_if_table_exist_Treasury(string connString)
        {
            string query = "select * from Treasury_assetclassification";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}


