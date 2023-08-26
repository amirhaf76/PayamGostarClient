using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Models.RestApiConfigBuilder
{
    internal interface IPayamGostarRestApiConfigBuilder
    {
        PayamGostarRestApiConfig Create();
    }

}