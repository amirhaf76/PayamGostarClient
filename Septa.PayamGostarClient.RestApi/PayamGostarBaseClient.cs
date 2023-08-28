using Septa.PayamGostarClient.RestApi.Exceptions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.RestApi
{
    public abstract class PayamGostarBaseClient
    {
        private readonly PayamGostarRestApiConfig _payamGostarClientConfig;

        public string BaseUrl { get; private set; }


        public PayamGostarBaseClient(PayamGostarRestApiConfig payamGostarClientConfig)
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
