using PayamGostarClient.ApiClient.ApiProvider;

namespace SeptaPay.PayamGostarClient.Initializer.Core.ApiClient.ApiProvider.Abstractions
{
    internal interface IPayamGostarApiProviderConfigBuilder
    {
        PayamGostarApiProviderConfig Create();
    }

}