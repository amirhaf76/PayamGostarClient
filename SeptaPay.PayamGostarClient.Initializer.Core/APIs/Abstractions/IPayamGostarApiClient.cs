using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions
{
    public interface IPayamGostarApiClient
    {
        IPayamGostarCustomizationApiClient CustomizationApi { get; }
    }
}