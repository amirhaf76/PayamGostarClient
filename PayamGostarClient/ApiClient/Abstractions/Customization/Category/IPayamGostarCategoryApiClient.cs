using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Search;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.Category
{
    public interface IPayamGostarCategoryApiClient
    {
        Task<ApiResponse<CategoryCreationResultDto>> CreateAsync(CategoryCreationRequestDto request);
        Task<ApiResponse<IEnumerable<CategoryGetResultDto>>> SearchAsync(CategorySearchRequestDto request);

    }
}
