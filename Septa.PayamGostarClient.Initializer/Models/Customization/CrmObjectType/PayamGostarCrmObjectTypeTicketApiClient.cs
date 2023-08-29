using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }


        public CrmObjectTypeResultDto Create(CrmObjectTypeTicketCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
        }

        public CrmObjectTypeTicketGetResultDto GetWithPriorityMatrix(CrmObjectTypeGetRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => GetWithPriorityMatrixAsync(request));
        }
    }


}
