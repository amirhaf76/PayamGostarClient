using PayamGostarClient.ApiClient.Abstractions.Customization.NumberTemplate;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Create;
using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Search;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.NumberTemplate
{
    public class PayamGostarNumberingTemplateApiClient : BaseApiClient, IPayamGostarNumberingTemplateApiClient
    {
        private readonly INumberingTemplateApiClient _numberingTemplateApiClient;

        public PayamGostarNumberingTemplateApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _numberingTemplateApiClient = ApiProviderFactory.CreateNumberingTemplateApiClient();
        }

        public async Task<ApiResponse<NumberingTemplateCreationResultDto>> CreateAsync(NumberingTemplateCreationRequestDto request)
        {
            try
            {
                var numberingTemplateCreationResult = await _numberingTemplateApiClient.PostV2ApiNumberingtemplateCreateAsync(request.ToVM());

                return numberingTemplateCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }

        public async Task<ApiResponse<IEnumerable<NumberingTemplateSearchResultDto>>> SearchAsync(NumberingTemplateSearchRequestDto request)
        {
            try
            {
                var numberingTemplateCreationResult = await _numberingTemplateApiClient.PostV2ApiNumberingtemplateSearchAsync(request.ToVM());

                return numberingTemplateCreationResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }
    }
}
