using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CategoryDtos.Search;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CategoryApiClientExtension
    {
        internal static CategoryCreationRequestVM ToVM(this CategoryCreationRequestDto dto)
        {
            return new CategoryCreationRequestVM
            {
                Name = dto.Name,
                UserKey = dto.UserKey,
                ParentId = dto.ParentId,
                OwnerUserId = dto.OwnerUserId,
                AddedByUser = dto.AddedByUser,
            };
        }

        internal static CategoryCreationResultDto ToDto(this CategoryCreationResultVM vm)
        {
            return new CategoryCreationResultDto
            {
                Id = vm.Id,
                Name = vm.Name,
                UserKey = vm.UserKey,
                AddedByUser = vm.AddedByUser,
                OwnerUserId = vm.OwnerUserId,
                ParentId = vm.ParentId,
            };
        }

        internal static CategorySearchRequestVM ToVM(this CategorySearchRequestDto vm)
        {
            return new CategorySearchRequestVM
            {
                Name = vm.Name,
                Key = vm.Key,
            };
        }

        internal static CategoryGetResultDto ToDto(this CategoryGetResultVM vm)
        {
            return new CategoryGetResultDto
            {
                Id = vm.Id,
                Name = vm.Name,
                ParentId = vm.ParentId,
            };
        }

    }
}
