using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Abstractions
{
    internal interface IPayamGostarApiProviderConfigBuilder
    {
        PayamGostarApiProviderConfig Create();
    }

}