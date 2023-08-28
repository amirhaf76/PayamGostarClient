using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ProductDtos.Get;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class ProductGroupApiClientExtension
    {
        internal static ProductCategoryCreationRequestVM ToVM(this ProductGroupCreationRequestDto dto)
        {
            return new ProductCategoryCreationRequestVM
            {
                Name = dto.Name,
                ParentGroupId = dto.ParentGroupId,
            };
        }

        internal static ProductGroupCreationResponseDto ToDto(this ProductCategoryCreationResultVM vm)
        {
            return new ProductGroupCreationResponseDto
            {
                Id = vm.Id,
                Name = vm.Name,
                ParentGroupId = vm.ParentGroupId,
            };
        }

        internal static ProductCategoryFilterRequestVM ToVM(this ProductGroupSearchRequestDto dto)
        {
            return new ProductCategoryFilterRequestVM
            {
                Name = dto.Name,
                ParentGroupId = dto.ParentGroupId,
            };
        }

        internal static ProductGroupSearchResponseDto ToDto(this ProductCategoryResultVM vm)
        {
            return new ProductGroupSearchResponseDto
            {
                Id = vm.Id,
                Name = vm.Name,
                ParentGroupId = vm.ParentGroupId,
            };
        }
    }
}
