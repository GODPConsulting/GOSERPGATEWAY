using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class PPE_apis_test
    {
        private readonly Integrated_test_broker _PPE_Server_Api_Broker;
        public PPE_apis_test(Integrated_test_broker PPE_Server_Api_Broker) =>
            _PPE_Server_Api_Broker = PPE_Server_Api_Broker;
        
        [Fact]
        public async Task Should_equal_default_gateway()
        {
            var testurls = new PPE();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _PPE_Server_Api_Broker.Return_PPE_appsettingsurls_async());

            baseurl.LiveGateway.Should().Be(testurls.DefaultGateway); 
        }
        
        [Fact]
        public async Task Should_be_successful_if_rightly_connected_main_client_app()
        {
            var testurls = new PPE();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _PPE_Server_Api_Broker.Return_PPE_appsettingsurls_async());

            baseurl.MainClient.Should().Be(testurls.MainClient);
        }

      

        [Fact]
        public async Task Should_be_successful_if_rightly_deployed_on_the_intended_server_connected_to_the_right_database()
        {
            var testurls = new PPE();

            var connectionstr = await _PPE_Server_Api_Broker.Return_PPE_appsettings_connectionstrings_async();

            connectionstr.Should().Be(testurls.connection_strings);
        }

        [Fact]
        public async Task Should_be_successful_if_PPE_sever_tables_are_updated()
        {
            var response = await _PPE_Server_Api_Broker.Access_PPE_tables();

            response.Should().Be(true);
        }

        [Fact]
        public async Task Should_be_successful_if_PPE_stream_templates_are_configured()
        {
            var response = await _PPE_Server_Api_Broker.Make_a_request_that_will_return_true_for_PPE();

            response.Should().BeTrue();
        }



    }
}

