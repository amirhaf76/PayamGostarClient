using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions
{
    public interface IPayamGostarApiClient
    {
        IPayamGostarCustomizationApiClient CustomizationApi { get; }
    }
}