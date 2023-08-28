using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Product
{
    public interface IPayamGostarProductGroupApiClient
    {
        Task<IEnumerable<ProductGroupSearchResponseDto>> SearchAsync(ProductGroupSearchRequestDto request);

        Task<ProductGroupCreationResponseDto> CreateAsync(ProductGroupCreationRequestDto request);
    }
}
