using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization
{
    public interface IPayamGostarCustomizationApiClient
    {

        IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi { get; }

        IPayamGostarPropertyGroupApiClient PropertyGroupApi { get; }

        IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi { get; }

        IPayamGostarNumberingTemplateApiClient NumberingTemplateApi { get; }

        IPayamGostarCategoryApiClient CategoryApi { get; }

        IPayamGostarProductGroupApiClient ProductGroupApi { get; }
    }


}