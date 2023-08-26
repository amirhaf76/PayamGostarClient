using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.Category;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.ExtendedProperty;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.NumberTemplate;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.ProductGroup;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.PropertyGroup;
using SeptaPay.PayamGostarClient.RestApi.Factory;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization
{
    public class PayamGostarCustomizationApiClient : BaseApiClient, IPayamGostarCustomizationApiClient
    {
        public PayamGostarCustomizationApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
        }

        public IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi => new PayamGostarExtendedPropertyApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi => new PayamGostarCrmObjectTypeApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarPropertyGroupApiClient PropertyGroupApi => new PayamGostarPropertyGroupApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarNumberingTemplateApiClient NumberingTemplateApi => new PayamGostarNumberingTemplateApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCategoryApiClient CategoryApi => new PayamGostarCategoryApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarProductGroupApiClient ProductGroupApi => new PayamGostarProductGroupApiClient(ApiClientConfig, ApiProviderFactory);
    }


}