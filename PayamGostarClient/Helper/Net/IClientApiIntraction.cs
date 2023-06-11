using System;
using System.Net.Http;

namespace PayamGostarClient.Helper.Net
{
    public interface IClientApiIntraction
    {
        string ClientId { get; set; }
        Guid DeviceId { get; set; }
        string DomainUrl { get; set; }
        string JwtToken { get; set; }

        HttpClient CreateHttpClient();
    }
}