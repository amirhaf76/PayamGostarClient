using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.ProductGroup
{
    public class PayamGostarProductGroupApiClient : BaseApiClient, IPayamGostarProductGroupApiClient
    {
        private readonly IProductCategoryClient _productCategoryClient;


        public PayamGostarProductGroupApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _productCategoryClient = ApiProviderFactory.CreateProductGroupClient();
        }


        public async Task<ProductGroupCreationResponseDto> CreateAsync(ProductGroupCreationRequestDto request)
        {
            try
            {
                var productGroupCreationResult = await _productCategoryClient.PostApiV2ProductcategoryCreateAsync(request.ToVM());

                return productGroupCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {

                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<IEnumerable<ProductGroupSearchResponseDto>> SearchAsync(ProductGroupSearchRequestDto request)
        {
            try
            {
                var gettingProductGroupResult = await _productCategoryClient.PostApiV2ProductcategorySearchAsync(request.ToVM());

                return gettingProductGroupResult.Result.Select(x => x.ToDto());
            }
            catch (ApiException e)
            {

                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
