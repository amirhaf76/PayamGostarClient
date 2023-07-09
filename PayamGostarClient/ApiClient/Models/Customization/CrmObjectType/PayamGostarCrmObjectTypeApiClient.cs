using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{

    public class PayamGostarCrmObjectTypeApiClient : BaseApiClient, IPayamGostarCrmObjectTypeApiClient
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeClient;

        public PayamGostarCrmObjectTypeApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
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


        public async Task<ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>>> SearchAsync(CrmObjectTypeSearchRequestDto request)
        {
            try
            {
                var searchResult = await _crmObjectTypeClient.PostApiV2CrmobjecttypeSearchAsync(request.ToVM());

                return searchResult.ConvertToApiResponse(result => result.Items.Select(crm => crm.ToDto()));
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }

        }
    }


}
