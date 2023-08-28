using Septa.PayamGostarClient.Initializer.Core.Enums;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel
{
    public interface ICustomizationCrmModel
    {
        CustomizationCrmType CustomizationCrmType { get; }
    }
}
