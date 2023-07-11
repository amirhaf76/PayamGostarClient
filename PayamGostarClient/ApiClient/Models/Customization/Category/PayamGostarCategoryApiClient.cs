using PayamGostarClient.ApiClient.Abstractions.Customization.Category;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Search;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.Category
{
    public class PayamGostarCategoryApiClient : BaseApiClient, IPayamGostarCategoryApiClient
    {
        private readonly ICategoryClient _categoryClient;

        public PayamGostarCategoryApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _categoryClient = ApiProviderFactory.CreateCategoryClient();
        }

        public async Task<ApiResponse<CategoryCreationResultDto>> CreateAsync(CategoryCreationRequestDto request)
        {
            try
            {
                var categoryCreationResult = await _categoryClient.PostApiV2CategoryCreateAsync(request.ToVM());

                return categoryCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }

        public async Task<ApiResponse<IEnumerable<CategoryGetResultDto>>> SearchAsync(CategorySearchRequestDto request)
        {
            try
            {
                var categoryCreationResult = await _categoryClient.PostApiV2CategorySearchAsync(request.ToVM());

                return categoryCreationResult.ConvertToApiResponse(result => result.Select(r => r.ToDto()));
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }
    }
}
