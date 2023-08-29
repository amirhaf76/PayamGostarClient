using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.ProductGroup
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

                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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

                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }

        public ProductGroupCreationResponseDto Create(ProductGroupCreationRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
        }

        public IEnumerable<ProductGroupSearchResponseDto> Search(ProductGroupSearchRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => SearchAsync(request));
        }

    }
}
