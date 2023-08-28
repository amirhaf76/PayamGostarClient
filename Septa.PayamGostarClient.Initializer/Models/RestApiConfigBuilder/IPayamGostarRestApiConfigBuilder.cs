using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Models.RestApiConfigBuilder
{
    internal interface IPayamGostarRestApiConfigBuilder
    {
        PayamGostarRestApiConfig Create();
    }

}