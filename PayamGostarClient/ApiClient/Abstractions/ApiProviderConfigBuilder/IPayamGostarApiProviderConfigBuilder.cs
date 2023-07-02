using PayamGostarClient.ApiClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Abstractions.ApiProviderConfigBuilder
{
    internal interface IPayamGostarApiProviderConfigBuilder
    {
        PayamGostarApiProviderConfig Create();
    }

}