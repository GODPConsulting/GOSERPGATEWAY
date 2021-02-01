using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class Credit_apis_test
    {
        private readonly Integrated_test_broker _Credit_Server_Api_Broker;
        public Credit_apis_test(Integrated_test_broker Credit_Server_Api_Broker) =>
            _Credit_Server_Api_Broker = Credit_Server_Api_Broker;
        
        [Fact]
        public async Task Should_equal_default_gateway()
        {
            var testurls = new Credit();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _Credit_Server_Api_Broker.Return_credit_appsettingsurls_async());

            baseurl.LiveGateway.Should().Be(testurls.DefaultGateway); 
        }
        
        [Fact]
        public async Task Should_be_successful_if_rightly_connected_main_client_app()
        {
            var testurls = new Credit();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _Credit_Server_Api_Broker.Return_credit_appsettingsurls_async());

            baseurl.MainClient.Should().Be(testurls.MainClient);
        }

        [Fact]
        public async Task Should_be_successful_if_rightly_connected_self_client_app()
        {
            var testurls = new Credit();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _Credit_Server_Api_Broker.Return_credit_appsettingsurls_async());

            baseurl.SelfClient.Should().Be(testurls.Frontend);
        }

        [Fact]
        public async Task Should_be_successful_if_rightly_deployed_on_the_intended_server_connected_to_the_right_database()
        {
            var testurls = new Credit();

            var connectionstr = await _Credit_Server_Api_Broker.Return_credit_appsettings_connectionstrings_async();

            connectionstr.Should().Be(testurls.connection_strings);
        }

        [Fact]
        public async Task Should_be_successful_if_Credit_sever_tables_are_updated()
        {
            var response = await _Credit_Server_Api_Broker.Login_into_service_async("customer/identity/login");

            response.Status.Message.FriendlyMessage.Should().Be("Invalid Password");
        }

        [Fact]
        public async Task Should_be_successful_if_default_data_like_loan_scheduletype_are_seeded()
        {
            var response = await _Credit_Server_Api_Broker.Return_credit_loan_schedule_type_async();

            response.Should().Be(true);
        }

        [Fact]
        public async Task Should_be_successful_if_stored_procedures_are_correctly_installed()
        {
            var response = await _Credit_Server_Api_Broker.Access_stored_procedures();

            response.Should().Be(true);
        }


        [Fact]
        public async Task Should_be_successful_if_sql_functions_are_correctly_installed()
        {
            var response = await _Credit_Server_Api_Broker.Access_sql_functions();

            response.Should().Be(true);
        }
         
    }
}

