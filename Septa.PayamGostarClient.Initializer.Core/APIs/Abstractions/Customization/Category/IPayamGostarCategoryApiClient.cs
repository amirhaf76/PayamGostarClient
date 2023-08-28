using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.Category
{
    public interface IPayamGostarCategoryApiClient
    {
        Task<CategoryCreationResultDto> CreateAsync(CategoryCreationRequestDto request);
        Task<IEnumerable<CategoryGetResultDto>> SearchAsync(CategorySearchRequestDto request);

    }
}
