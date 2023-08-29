using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePaymentApiClient : BaseApiClient, IPayamGostarCrmObjectTypePaymentApiClient
    {
        private readonly ICrmObjectTypePaymentApiClient _paymentApiClient;

        public PayamGostarCrmObjectTypePaymentApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _paymentApiClient = ApiProviderFactory.CreateCrmObjectTypePaymentApiClient();
        }

        public CrmObjectTypeResultDto Create(CrmObjectTypePaymentCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
