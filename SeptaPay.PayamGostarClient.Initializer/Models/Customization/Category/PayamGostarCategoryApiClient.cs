using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Search;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.Category
{
    public class PayamGostarCategoryApiClient : BaseApiClient, IPayamGostarCategoryApiClient
    {
        private readonly ICategoryClient _categoryClient;

        public PayamGostarCategoryApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _categoryClient = ApiProviderFactory.CreateCategoryClient();
        }

        public async Task<CategoryCreationResultDto> CreateAsync(CategoryCreationRequestDto request)
        {
            try
            {
                var categoryCreationResult = await _categoryClient.PostApiV2CategoryCreateAsync(request.ToVM());

                return categoryCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<IEnumerable<CategoryGetResultDto>> SearchAsync(CategorySearchRequestDto request)
        {
            try
            {
                var categoryCreationResult = await _categoryClient.PostApiV2CategorySearchAsync(request.ToVM());

                return categoryCreationResult.Result.Select(r => r.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
