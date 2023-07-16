using PayamGostarClient.ApiClient.Dtos.ProductDtos.Create;
using PayamGostarClient.ApiClient.Dtos.ProductDtos.Get;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.Product
{
    public interface IPayamGostarProductGroupApiClient
    {
        Task<IEnumerable<ProductGroupGetResponseDto>> GetAsync(ProductGroupGetRequestDto request);

        Task<IEnumerable<ProductGroupCreationResponseDto>> CreateAsync(ProductGroupCreationRequestDto request);
    }
}
