using APIGateway.AcceptanceTest.APIs;
using APIGateway.AcceptanceTest.Test_models.Response;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    { 
        public async Task<string> Return_credit_appsettingsurls_async()
        {
            var test_url = new Credit();
            var client = new HttpClient();
            var response =  await client.GetStringAsync($"{test_url.Backend}test_response/credit/get/baseurls");
            return response; 
        }

        public async Task<string> Return_credit_appsettings_connectionstrings_async()
        {
            var test_url = new Credit();
            var client = new HttpClient();
            var response = await client.GetStringAsync($"{test_url.Backend}test_response/credit/get/connectionstring");
            return response;
        } 
         
        public async Task<bool> Return_credit_loan_schedule_type_async()
        {
            var test_url = new Credit();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/credit/get/connectionstring");
            return Read_credit_loanscheduletype(conn_str);
        }


        private static bool Read_credit_loanscheduletype(string connectionString)
        {

            string queryString = "SELECT * FROM dbo.credit_loanscheduletype;";
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


        public async Task<bool> Access_stored_procedures()
        {
            var test_url = new Credit();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/credit/get/connectionstring");
            return Check_if_stored_procedures_exist(conn_str);
        }

        public static bool Check_if_stored_procedures_exist(string connString)
        { 
            string query = "select * from sysobjects where type='P' and name='spp_CalculateIndividualCustomerLoanPD_Temp'"; 
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

        public async Task<bool> Access_sql_functions()
        {
            var test_url = new Credit();
            var client = new HttpClient();
            var conn_str = await client.GetStringAsync($"{test_url.Backend}test_response/credit/get/connectionstring");
            return Check_if_stored_procedures_exist(conn_str);
        }


        public static bool Check_if_credit_sql_functions_exist(string connString)
        {
            string query = "IF EXISTS(SELECT * FROM   sys.objects WHERE  object_id = OBJECT_ID(N'[dbo].[foo]')  AND type IN(N'FN', N'IF', N'TF', N'FS', N'FT'))  DROP FUNCTION[dbo].[foo]  GO";
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


