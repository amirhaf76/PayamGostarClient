using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePaymentApiClient : BaseApiClient, IPayamGostarCrmObjectTypePaymentApiClient
    {
        private readonly ICrmObjectTypePaymentApiClient _paymentApiClient;

        public PayamGostarCrmObjectTypePaymentApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _paymentApiClient = ApiProviderFactory.CreateCrmObjectTypePaymentApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypePaymentCreateRequestDto request)
        {
            try
            {
                var paymentCreationResult = await _paymentApiClient.PostApiV2CrmobjecttypePaymentCreateAsync(request.ToVM());

                return paymentCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }
}
