﻿using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeStageApiClient : BaseApiClient, IPayamGostarCrmObjectTypeStageApiClient
    {
        private readonly ICrmObjectTypeStageApiClient _crmObjectTypeStageApiClient;

        public PayamGostarCrmObjectTypeStageApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeStageApiClient = ApiProviderFactory.CreateCrmObjectTypeStageApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeStageCreationResultDto>> CreateAsync(CrmObjectTypeStageCreationRequestDto request)
        {
            try
            {
                var stageCreationResult = await _crmObjectTypeStageApiClient.PostApiV2CrmobjecttypestageCreateAsync(request.ToVM());

                return stageCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }

        }

        public async Task<ApiResponse<IEnumerable<CrmObjectTypeStageGetResultDto>>> GetStagesAsync(Guid crmObjectId)
        {
            var request = new CrmObjectTypeStageGetCollectionRequestVM
            {
                CrmObjectTypeId = crmObjectId,
            };

            try
            {
                var stageCreationResult = await _crmObjectTypeStageApiClient.PostApiV2CrmobjecttypestageGetcrmobjecttypestagesAsync(request);

                return stageCreationResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }

        }

    }
}