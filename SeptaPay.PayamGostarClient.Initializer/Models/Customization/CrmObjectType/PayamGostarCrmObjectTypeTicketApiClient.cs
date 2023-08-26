using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    internal class PayamGostarCrmObjectTypeTicketApiClient : BaseApiClient, IPayamGostarCrmObjectTypeTicketApiClient
    {
        private readonly ICrmObjectTypeTicketApiClient _crmObjectTypeTicketApiClient;

        public PayamGostarCrmObjectTypeTicketApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeTicketApiClient = ApiProviderFactory.CreateCrmObjectTypeTicketApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeTicketCreateRequestDto request)
        {
            try
            {
                var ticketCreationResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketCreateAsync(request.ToVM());

                return ticketCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<CrmObjectTypeTicketGetResultDto> GetWithPriorityMatrixAsync(CrmObjectTypeGetRequestDto request)
        {
            try
            {
                var ticketGettingResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketGetAsync(request.ToVM());

                var ticketMatrixResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketGetprioritymatrixAsync(new CrmObjectTypeTicketPriorityMatrixGetRequestVM
                {
                    CrmObjectTypeId = ticketGettingResult.Result.Id,
                });

                var dto = ticketGettingResult.Result.ToDto();

                dto.PriorityMatrix = new PriorityMatrixsGetResultDto
                {
                    Details = ticketMatrixResult.Result.Select(mx => mx.ToDto()).AsEnumerable()
                };
                return dto;
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }


}
