using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PayamGostarClient.ApiServices.Models
{
    internal class CrmObjectTypeTicketService : BaseApiService, ICrmObjectTypeTicketService
    {
        private readonly ICrmObjectTypeTicketApiClient _crmObjectTypeTicketApiClient;

        public CrmObjectTypeTicketService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _crmObjectTypeTicketApiClient = clientFactory.CreateCrmObjectTypeTicketApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeTicketCreateRequestDto request)
        {
            try
            {
                var ticketCreationResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketCreateAsync(request.ToVM());

                return ticketCreationResult.ConvertToApiResponse(result => result.ConvertToCrmObjectTypeResultDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }

        public async Task<ApiResponse<CrmObjectTypeTicketGetResultDto>> GetWithPriorityMatrixAsync(CrmObjectTypeGetRequestDto request)
        {
            try
            {
                var ticketGettingResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketGetAsync(request.ConvertToCrmObjectTypeGetRequestVM());

                var ticketMatrixResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketGetprioritymatrixAsync(new CrmObjectTypeTicketPriorityMatrixGetRequestVM
                {
                    CrmObjectTypeId = ticketGettingResult.Result.Id,
                });

                var dto = ticketGettingResult.ConvertToApiResponse(result => result.ToDto());

                dto.Result.PriorityMatrix = new PriorityMatrixsGetResultDto
                {
                    Details = ticketMatrixResult.Result.Select(mx => mx.ToDto()).AsEnumerable()
                };
                return dto;
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }
}
