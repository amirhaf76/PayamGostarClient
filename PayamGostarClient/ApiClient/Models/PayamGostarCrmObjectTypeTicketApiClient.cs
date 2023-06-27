﻿using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models
{
    internal class PayamGostarCrmObjectTypeTicketApiClient : BaseApiClient, IPayamGostarCrmObjectTypeTicketApiClient
    {
        private readonly ICrmObjectTypeTicketApiClient _crmObjectTypeTicketApiClient;

        public PayamGostarCrmObjectTypeTicketApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeTicketApiClient = ApiProviderFactory.CreateCrmObjectTypeTicketApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeTicketCreateRequestDto request)
        {
            try
            {
                var ticketCreationResult = await _crmObjectTypeTicketApiClient.PostApiV2CrmobjecttypeTicketCreateAsync(request.ToVM());

                return ticketCreationResult.ConvertToApiResponse(result => result.ToDto());
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
