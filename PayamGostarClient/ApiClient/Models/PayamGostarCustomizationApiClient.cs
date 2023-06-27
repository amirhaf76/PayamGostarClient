using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Factory;
using System;
using PayamGostarClient.ApiClient.Abstractions;

namespace PayamGostarClient.ApiClient.Models
{
    public class PayamGostarCustomizationApiClient : BaseApiClient, IPayamGostarCustomizationApiClient
    {
        public PayamGostarCustomizationApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
        }

        public IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi => new PayamGostarExtendedPropertyApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi => new PayamGostarCrmObjectTypeApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarPropertyGroupApiClient PropertyGroupApi => new PayamGostarPropertyGroupApiClient(ApiClientConfig, ApiProviderFactory);
    }


}