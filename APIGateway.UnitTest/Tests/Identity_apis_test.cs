using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class Identity_apis_test
    {
        private readonly Integrated_test_broker _identity_Server_Api_Broker;
        public Identity_apis_test(Integrated_test_broker identity_Server_Api_Broker) =>
            _identity_Server_Api_Broker = identity_Server_Api_Broker;
        
        [Fact]
        public async Task Should_equal_default_gateway()
        {
            var testurls = new Identity_server();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _identity_Server_Api_Broker.Return_identity_appsettingsurls_async());

            baseurl.LiveGateway.Should().Be(testurls.DefaultGateway); 
        }
        
        [Fact]
        public async Task Should_be_successful_if_rightly_connected_main_client_app()
        {
            var testurls = new Identity_server();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _identity_Server_Api_Broker.Return_identity_appsettingsurls_async());

            baseurl.MainClient.Should().Be(testurls.Frontend);
        }
        
        [Fact]
        public async Task Should_be_successful_if_rightly_deployed_on_the_intended_server_connected_to_the_right_database()
        {
            var testurls = new Identity_server();

            var connectionstr = await _identity_Server_Api_Broker.Return_identity_appsettings_connectionstrings_async();

            connectionstr.Should().Be(testurls.connection_strings);
        }

        [Fact]
        public async Task Should_be_successful_if_identity_sever_tables_are_updated()
        {
            var response = await _identity_Server_Api_Broker.Login_into_service_async("identity/login");

            response.Status.Message.FriendlyMessage.Should().Be("User does not exist");
        }

        [Fact]
        public async Task Should_be_successful_if_default_data_like_operations_are_seeded()
        {
            var response = await _identity_Server_Api_Broker.Return_identity_server_operatons_async();

            response.Should().Be(true);
        }

        [Fact]
        public async Task Should_be_successful_if_finance_stream_templates_are_configured()
        {
            var response = await _identity_Server_Api_Broker.Make_a_request_that_will_return_true_for_identity_server();

            response.Should().BeTrue();
        }

    

    }
}

