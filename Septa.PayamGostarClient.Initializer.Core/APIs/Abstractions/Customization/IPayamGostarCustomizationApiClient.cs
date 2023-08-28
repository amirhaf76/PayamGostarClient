using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization
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