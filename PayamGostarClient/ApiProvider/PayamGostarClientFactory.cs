using PayamGostarClient.ApiProvider.Abstractions;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarClientFactory : IPayamGostarClientAbstractFactory
    {
        private readonly PayamGostarClientConfig _config;

        public PayamGostarClientFactory(PayamGostarClientConfig config)
        {
            _config = config;
        }

        public ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient()
        {
            return new CrmObjectTypeApiClient(_config);
        }
    }
}
