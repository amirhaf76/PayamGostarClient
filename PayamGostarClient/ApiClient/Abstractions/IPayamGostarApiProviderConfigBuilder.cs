using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarApiProviderConfigBuilder
    {
        PayamGostarApiProviderConfig Create();
    }

}