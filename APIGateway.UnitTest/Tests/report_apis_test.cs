using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Response;
using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class report_apis_test
    {
        private readonly Integrated_test_broker _identity_Server_Api_Broker;
        public report_apis_test(Integrated_test_broker identity_Server_Api_Broker) =>
            _identity_Server_Api_Broker = identity_Server_Api_Broker;
          
        [Fact]
        public async Task Should_equal_default_gateway()
        {
            var testurls = new Report();

            BaseURIs baseurl = JsonConvert.DeserializeObject<BaseURIs>(await _identity_Server_Api_Broker.Return_report_appsettingsurls_async());

            baseurl.LiveGateway.Should().Be(testurls.DefaultGateway);   
        } 
    }
}

