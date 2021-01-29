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
            return Check_if_table_exist_finance(conn_str);
        }

        public static bool Check_if_table_exist_finance(string connString)
        {
            string query = "select * from fin_transaction";
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


