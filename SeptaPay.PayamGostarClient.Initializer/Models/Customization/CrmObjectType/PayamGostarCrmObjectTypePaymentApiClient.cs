using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePaymentApiClient : BaseApiClient, IPayamGostarCrmObjectTypePaymentApiClient
    {
        private readonly ICrmObjectTypePaymentApiClient _paymentApiClient;

        public PayamGostarCrmObjectTypePaymentApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _paymentApiClient = ApiProviderFactory.CreateCrmObjectTypePaymentApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypePaymentCreateRequestDto request)
        {
            try
            {
                var paymentCreationResult = await _paymentApiClient.PostApiV2CrmobjecttypePaymentCreateAsync(request.ToVM());

                return paymentCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
