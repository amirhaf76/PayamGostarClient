using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System;
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

        public async Task<ApiResponse<CrmObjectTypeTicketGetResultDto>> GetAsync(CrmObjectTypeGetRequestDto request)
        {
            try
            {
                var ticketGettingResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketGetAsync(request.ConvertToCrmObjectTypeGetRequestVM());

                return ticketGettingResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }
}
