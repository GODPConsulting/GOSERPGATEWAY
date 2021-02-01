using APIGateway.AcceptanceTest.APIs;
using APIGateway.AcceptanceTest.Test_endpints.V1;
using APIGateway.AcceptanceTest.Test_models.Identity_models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Integrated_test_broker
    {
        public async ValueTask<Login> Login_staff_async(Login request) =>
            await apiFactoryClient.PostContentAsync(Test_endpont_routes.Identity.LOGIN, request);

        public async ValueTask<Staff_user_detail> Get_staff_user_profile_async(string token) =>
            await this.apiFactoryClient.GetContentAsync<Staff_user_detail>($"{Test_endpont_routes.Identity.FETCH_USERDETAILS}/{token}");
         
        public async Task Authenticate_async(HttpClient client)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetJWTAsync(client));
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            
        }

        private async Task<string> GetJWTAsync(HttpClient client)
        {
            var testurl = new Identity_server(); 
            try
            {
                var response = await client.PostAsJsonAsync($"{testurl.Backend}api/v1/identity/login",
                    new Login
                    {
                        UserName = "godpadmin",
                        Password = "Password@1"
                    });
                
                var registrationResponse = await response.Content.ReadAsAsync<AuthResponse>();
                return registrationResponse.Token;
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }
    }
}
