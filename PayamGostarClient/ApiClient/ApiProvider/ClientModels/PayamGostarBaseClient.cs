using PayamGostarClient.ApiProvider.Exceptions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiProvider.ClientModels
{
    internal abstract class PayamGostarBaseClient
    {
        private readonly PayamGostarApiProviderConfig _payamGostarClientConfig;

        public string BaseUrl { get; private set; }


        public PayamGostarBaseClient(PayamGostarApiProviderConfig payamGostarClientConfig)
        {
            _payamGostarClientConfig = payamGostarClientConfig;

            SettingUrl();
        }


        protected Task<HttpClient> CreateHttpClientAsync(CancellationToken ct = default)
        {
            return Task.FromResult(CreateHttpClient());
        }


        private void SettingUrl()
        {
            if (_payamGostarClientConfig.ClientApiIntraction.DomainUrl == null)
            {
                throw new UrlApiProviderIsNullException();
            }

            BaseUrl = _payamGostarClientConfig.ClientApiIntraction.DomainUrl;
        }

        private HttpClient CreateHttpClient()
        {
            if (_payamGostarClientConfig.ClientApiIntraction == null)
            {
                throw new HttpClientCreationException();
            }

            return _payamGostarClientConfig.ClientApiIntraction.CreateHttpClient();
        }
    }
}
