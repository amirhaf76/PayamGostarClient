using PayamGostarClient.ApiClient.Dtos.ProductDtos.Create;
using PayamGostarClient.ApiClient.Dtos.ProductDtos.Get;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.Product
{
    public interface IPayamGostarProductGroupApiClient
    {
        Task<ApiResponse<IEnumerable<ProductGroupSearchResponseDto>>> SearchAsync(ProductGroupSearchRequestDto request);

        Task<ApiResponse<ProductGroupCreationResponseDto>> CreateAsync(ProductGroupCreationRequestDto request);
    }
}
