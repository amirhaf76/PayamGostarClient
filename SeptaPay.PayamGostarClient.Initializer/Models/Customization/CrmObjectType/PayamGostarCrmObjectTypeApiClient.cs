using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{

    public class PayamGostarCrmObjectTypeApiClient : BaseApiClient, IPayamGostarCrmObjectTypeApiClient
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeClient;

        public PayamGostarCrmObjectTypeApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeClient = ApiProviderFactory.CreateCrmObjectTypeApiClient();
        }

        public IPayamGostarCrmObjectTypeFormApiClient FormApi => new PayamGostarCrmObjectTypeFormApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeStageApiClient StageApi => new PayamGostarCrmObjectTypeStageApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeTicketApiClient TicketApi => new PayamGostarCrmObjectTypeTicketApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeIdentityApiClient IdentityApi => new PayamGostarCrmObjectTypeIdentityApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeInvoiceApiClient InvoiceApi => new PayamGostarCrmObjectTypeInvoiceApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypePurchaseInvoiceApiClient PurchaseInvoiceApi => new PayamGostarCrmObjectTypePurchaseInvoiceApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeReturnInvoiceApiClient ReturnInvoiceApi => new PayamGostarCrmObjectTypeReturnInvoiceApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient ReturnPurchaseInvoiceApi => new PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeQuoteApiClient QuoteApi => new PayamGostarCrmObjectTypeQuoteApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypePurchaseQuoteApiClient PurchaseQuoteApi => new PayamGostarCrmObjectTypePurchaseQuoteApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeReceiptApiClient ReceiptApi => new PayamGostarCrmObjectTypeReceiptApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypePaymentApiClient PaymentApi => new PayamGostarCrmObjectTypePaymentApiClient(ApiClientConfig, ApiProviderFactory);


        public async Task<IEnumerable<CrmObjectTypeSearchResultDto>> SearchAsync(CrmObjectTypeSearchRequestDto request)
        {
            try
            {
                var searchResult = await _crmObjectTypeClient.PostApiV2CrmobjecttypeSearchAsync(request.ToVM());

                return searchResult.Result.Items.Select(crm => crm.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(request.ToString());
            }

        }
    }


}
