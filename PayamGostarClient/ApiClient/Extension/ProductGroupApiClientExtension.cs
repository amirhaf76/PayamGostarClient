using PayamGostarClient.ApiClient.Dtos.ProductDtos.Create;
using PayamGostarClient.ApiClient.Dtos.ProductDtos.Get;
using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class ProductGroupApiClientExtension
    {
        internal static ProductGroupCreationRequestVM ToVM(this ProductGroupCreationRequestDto dto)
        {
            return new ProductGroupCreationRequestVM
            {
                Name = dto.Name,
                ParentGroupId = dto.ParentGroupId,
            };
        }

        internal static ProductGroupCreationResponseDto ToDto(this ProductGroupCreationResponseVM vm)
        {
            return new ProductGroupCreationResponseDto
            {
                Id = vm.Id,
                Name = vm.Name,
                ParentGroupId = vm.ParentGroupId,
            };
        }

        internal static ProductGroupFilterRequestVM ToVM(this ProductGroupGetRequestDto dto)
        {
            return new ProductGroupFilterRequestVM
            {
                Name = dto.Name,
                ParentGroupId = dto.ParentGroupId,
            };
        }

        internal static ProductGroupGetResponseDto ToDto(this ProductGroupResponseVM vm)
        {
            return new ProductGroupGetResponseDto
            {
                Id = vm.Id,
                Name = vm.Name,
                ParentGroupId = vm.ParentGroupId,
            };
        }
    }
}
