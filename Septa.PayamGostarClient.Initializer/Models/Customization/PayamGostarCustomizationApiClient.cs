using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;
using Septa.PayamGostarClient.Initializer.Models.Customization.Category;
using Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Models.Customization.ExtendedProperty;
using Septa.PayamGostarClient.Initializer.Models.Customization.NumberTemplate;
using Septa.PayamGostarClient.Initializer.Models.Customization.ProductGroup;
using Septa.PayamGostarClient.Initializer.Models.Customization.PropertyGroup;
using Septa.PayamGostarClient.RestApi.Factory;

namespace Septa.PayamGostarClient.Initializer.Models.Customization
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