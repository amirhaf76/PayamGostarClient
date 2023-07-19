using PayamGostarClient.ApiClient.Abstractions.Customization.Product;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.ProductDtos.Create;
using PayamGostarClient.ApiClient.Dtos.ProductDtos.Get;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.ProductGroup
{
    public class PayamGostarProductGroupApiClient : BaseApiClient, IPayamGostarProductGroupApiClient
    {
        private readonly IProductGroupClient _productGroupClient;


        public PayamGostarProductGroupApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _productGroupClient = ApiProviderFactory.CreateProductGroupClient();
        }


        public async Task<ApiResponse<ProductGroupCreationResponseDto>> CreateAsync(ProductGroupCreationRequestDto request)
        {
            try
            {
                var productGroupCreationResult = await _productGroupClient.PostApiV2ProductgroupCreateAsync(request.ToVM());

                return productGroupCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {

                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductGroupGetResponseDto>>> GetAsync(ProductGroupGetRequestDto request)
        {
            try
            {
                var gettingProductGroupResult = await _productGroupClient.PostApiV2ProductgroupGetAsync(request.ToVM());

                return gettingProductGroupResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {

                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }
    }
}
