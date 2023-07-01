using PayamGostarClient.ApiClient.Abstractions.Customization;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarApiClient
    {
        IPayamGostarCustomizationApiClient CustomizationApi { get; }
    }
}