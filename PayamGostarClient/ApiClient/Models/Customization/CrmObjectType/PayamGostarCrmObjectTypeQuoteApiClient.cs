using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeQuoteApiClient : BaseApiClient, IPayamGostarCrmObjectTypeQuoteApiClient
    {
        private readonly ICrmObjectTypeQuoteApiClient _saleQuoteApiClient;

        public PayamGostarCrmObjectTypeQuoteApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _saleQuoteApiClient = apiProviderFactory.CreateCrmObjectTypeQuoteApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeQuoteCreateRequestDto request)
        {
            try
            {
                var quoteCreationResult = await _saleQuoteApiClient.PostApiV2CrmobjecttypeQuoteCreateAsync(request.ToVM());

                return quoteCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }
    }
}
