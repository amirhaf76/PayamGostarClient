using PayamGostarClient.ApiProvider.Exceptions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarBaseClient
    {
        private readonly PayamGostarClientConfig _payamGostarClientConfig;

        public string BaseUrl { get; private set; }


        public PayamGostarBaseClient(PayamGostarClientConfig payamGostarClientConfig)
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
            if (_payamGostarClientConfig.Url == null)
            {
                throw new UrlApiProviderIsNullException();
            }

            BaseUrl = _payamGostarClientConfig.Url;
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
