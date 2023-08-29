using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.NumberTemplate;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.NumberTemplate
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }

        public NumberingTemplateCreationResultDto Create(NumberingTemplateCreationRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
        }

        public IEnumerable<NumberingTemplateSearchResultDto> Search(NumberingTemplateSearchRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => SearchAsync(request));
        }

    }
}
