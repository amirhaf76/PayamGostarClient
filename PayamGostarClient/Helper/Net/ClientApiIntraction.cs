using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PayamGostarClient.Helper.Net
{
    public class ClientApiIntraction : IClientApiIntraction
    {
        public virtual string BasicParam { get; set; }

        public virtual string JwtToken { get; set; }

        public virtual Guid DeviceId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual string DomainUrl { get; set; }

        private void AddAuthenticationHeader(HttpClient client)
        {
            if (!string.IsNullOrEmpty(JwtToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            }

            if (!string.IsNullOrEmpty(BasicParam))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", BasicParam);
            }
        }

        private void AddDeviceId(HttpClient httpClient)
        {
            if (DeviceId != Guid.Empty)
            {
                httpClient.DefaultRequestHeaders.Add("deviceId", DeviceId.ToString());
            }
        }

        private void AddClientId(HttpClient httpClient)
        {
            if (!string.IsNullOrEmpty(ClientId))
            {
                httpClient.DefaultRequestHeaders.Add("clientId", ClientId);
            }
        }

        public virtual HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            AddAuthenticationHeader(httpClient);

            AddClientId(httpClient);

            AddDeviceId(httpClient);

            return httpClient;
        }
    }
}
