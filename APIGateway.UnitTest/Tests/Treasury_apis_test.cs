using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class Treasury_apis_test
    {
        private readonly Integrated_test_broker _Treasury_Server_Api_Broker;
        public Treasury_apis_test(Integrated_test_broker Treasury_Server_Api_Broker) =>
            _Treasury_Server_Api_Broker = Treasury_Server_Api_Broker;
        
        [Fact]
        public async Task Should_equal_default_gateway()
        {
            var testurls = new Treasury();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _Treasury_Server_Api_Broker.Return_Treasury_appsettingsurls_async());

            baseurl.LiveGateway.Should().Be(testurls.DefaultGateway); 
        }
        
        [Fact]
        public async Task Should_be_successful_if_rightly_connected_main_client_app()
        {
            var testurls = new Treasury();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _Treasury_Server_Api_Broker.Return_Treasury_appsettingsurls_async());

            baseurl.MainClient.Should().Be(testurls.MainClient);
        }

      

        [Fact]
        public async Task Should_be_successful_if_rightly_deployed_on_the_intended_server_connected_to_the_right_database()
        {
            var testurls = new Treasury();

            var connectionstr = await _Treasury_Server_Api_Broker.Return_Treasury_appsettings_connectionstrings_async();

            connectionstr.Should().Be(testurls.connection_strings);
        }

        [Fact]
        public async Task Should_be_successful_if_Treasury_sever_tables_are_updated()
        {
            var response = await _Treasury_Server_Api_Broker.Access_Treasury_tables();

            response.Should().Be(true);
        }

        
    }
}

