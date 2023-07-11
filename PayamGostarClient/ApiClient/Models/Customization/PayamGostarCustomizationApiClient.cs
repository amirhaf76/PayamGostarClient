using PayamGostarClient.ApiClient.Abstractions.Customization;
using PayamGostarClient.ApiClient.Abstractions.Customization.Category;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.NumberTemplate;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Models.Customization.Category;
using PayamGostarClient.ApiClient.Models.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Models.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Models.Customization.NumberTemplate;
using PayamGostarClient.ApiClient.Models.Customization.PropertyGroup;

namespace PayamGostarClient.ApiClient.Models.Customization
{
    public class PayamGostarCustomizationApiClient : BaseApiClient, IPayamGostarCustomizationApiClient
    {
        public PayamGostarCustomizationApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
        }

        public IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi => new PayamGostarExtendedPropertyApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi => new PayamGostarCrmObjectTypeApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarPropertyGroupApiClient PropertyGroupApi => new PayamGostarPropertyGroupApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarNumberingTemplateApiClient NumberingTemplateApi => new PayamGostarNumberingTemplateApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCategoryApiClient CategoryApi => new PayamGostarCategoryApiClient(ApiClientConfig, ApiProviderFactory);
    }


}