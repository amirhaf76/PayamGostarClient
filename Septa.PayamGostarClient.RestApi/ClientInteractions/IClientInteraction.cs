﻿using System;
using System.Net.Http;

namespace Septa.PayamGostarClient.RestApi.ClientInteractions
{
    public interface IClientInteraction
    {
        string ClientId { get; set; }
        Guid DeviceId { get; set; }
        string DomainUrl { get; set; }
        string JwtToken { get; set; }

        HttpClient CreateHttpClient();
    }
}