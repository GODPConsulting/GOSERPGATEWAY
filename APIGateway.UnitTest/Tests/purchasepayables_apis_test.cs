using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class purchasepayablles_apis_test
    {
        private readonly Integrated_test_broker _identity_Server_Api_Broker;
        public purchasepayablles_apis_test(Integrated_test_broker identity_Server_Api_Broker) =>
            _identity_Server_Api_Broker = identity_Server_Api_Broker;
          
        [Fact]
        public async Task Should_equal_default_gateway()
        {
            var testurls = new Purchase_and_payable();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _identity_Server_Api_Broker.Return_purchase_payables_appsettingsurls_async());

            baseurl.LiveGateway.Should().Be(testurls.DefaultGateway);   
        }
         
        [Fact]
        public async Task Should_be_successful_if_rightly_connected_main_client_app()
        {
            var testurls = new Purchase_and_payable();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _identity_Server_Api_Broker.Return_purchase_payables_appsettingsurls_async());

            baseurl.MainClient.Should().Be(testurls.MainClient);
        }

        [Fact]
        public async Task Should_be_successful_if_rightly_connected_self_client_app()
        {
            var testurls = new Purchase_and_payable();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _identity_Server_Api_Broker.Return_purchase_payables_appsettingsurls_async());

            baseurl.SelfClient.Should().Be(testurls.Frontend);
        }

        [Fact]
        public async Task Should_be_successful_if_rightly_deployed_on_the_intended_server_connected_to_the_right_database()
        {
            var testurls = new Purchase_and_payable();

            var connectionstr = await _identity_Server_Api_Broker.Return_purchase_payables_appsettings_connectionstrings_async();

            connectionstr.Should().Be(testurls.connection_strings);
        }

        [Fact]
        public async Task Should_be_successful_if_purchase_payables_stream_templates_are_configured()
        {
            var response = await _identity_Server_Api_Broker.Login_into_service_async("ppidentity/login"); 

            response.Status.Message.FriendlyMessage.Should().Be("User does not exist");
        }

        [Fact]
        public async Task Should_be_successful_if_purchase_payables_tables_are_updated()
        { 
            var response = await _identity_Server_Api_Broker.Access_purchase_payables_tables();

            response.Should().Be(true);
        }

    

    }
}

