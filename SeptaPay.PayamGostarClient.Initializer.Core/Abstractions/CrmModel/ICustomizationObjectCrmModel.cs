using SeptaPay.PayamGostarClient.Initializer.Core.Enums;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel
{
    public interface ICustomizationCrmModel
    {
        CustomizationCrmType CustomizationCrmType { get; }
    }
}
