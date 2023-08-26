using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Search;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.NumberTemplate
{
    public class PayamGostarNumberingTemplateApiClient : BaseApiClient, IPayamGostarNumberingTemplateApiClient
    {
        private readonly INumberingTemplateApiClient _numberingTemplateApiClient;

        public PayamGostarNumberingTemplateApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _numberingTemplateApiClient = ApiProviderFactory.CreateNumberingTemplateApiClient();
        }

        public async Task<NumberingTemplateCreationResultDto> CreateAsync(NumberingTemplateCreationRequestDto request)
        {
            try
            {
                var numberingTemplateCreationResult = await _numberingTemplateApiClient.PostV2ApiNumberingtemplateCreateAsync(request.ToVM());

                return numberingTemplateCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<IEnumerable<NumberingTemplateSearchResultDto>> SearchAsync(NumberingTemplateSearchRequestDto request)
        {
            try
            {
                var numberingTemplateCreationResult = await _numberingTemplateApiClient.PostV2ApiNumberingtemplateSearchAsync(request.ToVM());

                return numberingTemplateCreationResult.Result.Select(x => x.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
