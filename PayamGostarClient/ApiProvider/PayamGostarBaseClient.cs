using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarBaseClient
    {
        private readonly PayamGostarClientConfig _payamGostarClientConfig;

        public PayamGostarBaseClient(PayamGostarClientConfig payamGostarClientConfig)
        {
            _payamGostarClientConfig = payamGostarClientConfig;

            BaseUrl = _payamGostarClientConfig.Url;
        }

        public string BaseUrl { get; private set; }

        protected Task<HttpClient> CreateHttpClientAsync(CancellationToken ct = default)
        {
            return Task.FromResult(new HttpClient());
        }
    }
}
