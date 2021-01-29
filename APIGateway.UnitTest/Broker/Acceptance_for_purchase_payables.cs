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

        public async Task<Backend_response> Login_into_purchase_payables_async()
        {
            var test_url = new Purchase_and_payable(); 
            var client = new HttpClient();
            var loginrequest = new Login();
            var jsoncontent = JsonConvert.SerializeObject(loginrequest);
            var buffercontent = Encoding.UTF8.GetBytes(jsoncontent);
            var bytecontent = new ByteArrayContent(buffercontent);
            bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{test_url.Backend}api/v1/ppidentity/login", bytecontent);
            var respnse_strings_value = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Backend_response>(respnse_strings_value);
        }

        //public static int GetTables(string connectionString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        // DataTable schema = connection.GetSchema("Tables");
        //        List<string> TableNames = new List<string>();

        //        DataTable schema = connection.GetSchema("IDENTITY_SERVER");
        //       var re = schema.TableName;

        //        //foreach (DataRow row in schema.Rows)
        //        //{
        //        //    TableNames.Add(row[0].ToString());
        //        //}
        //        //return TableNames; 
        //    }
        //}
    }
}


