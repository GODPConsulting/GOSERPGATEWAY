using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    [CollectionDefinition(nameof(Api_test_collection))]
    public class Api_test_collection : ICollectionFixture<Integrated_test_broker> { }
}
 