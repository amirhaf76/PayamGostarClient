using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.Category
{
    public class PayamGostarCategoryApiClient : BaseApiClient, IPayamGostarCategoryApiClient
    {
        private readonly ICategoryClient _categoryClient;

        public PayamGostarCategoryApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _categoryClient = ApiProviderFactory.CreateCategoryClient();
        }

        public CategoryCreationResultDto Create(CategoryCreationRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }

        public IEnumerable<CategoryGetResultDto> Search(CategorySearchRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => SearchAsync(request));
        }
    }
}
