using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using System.Collections.Generic;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class CrmObjectTypeServiceExtension
    {
        public static CrmObjectTypeSearchRequestVM ToVM(this CrmObjectTypeSearchRequestDto crmModel)
        {
            return new CrmObjectTypeSearchRequestVM
            {
                Code = crmModel.Code,
                CrmObjectTypeIndex = crmModel.CrmOjectTypeIndex,
                PageNumber = crmModel.PageNumber,
                PageSize = crmModel.PageSiz,
                Name = crmModel.Name,
            };
        }

        public static CrmObjectTypeSearchResultDto ToDto(this CrmObjectTypeGetResultVM viewModel)
        {
            var groupDictionary = new Dictionary<int, PropertyGroupGetResultDto>();

            foreach (var group in viewModel.Groups)
            {
                groupDictionary.Add(group.Id, new PropertyGroupGetResultDto
                {
                    Name = group.Name,
                    NameResourceKey = group.NameResourceKey,
                    CountOfColumns = group.CountOfColumns,
                    ExpandForView = group.ExpandForView,
                    Id = group.Id,
                });
            }

            var properties = viewModel.Properties.Select(property =>
            {
                const int INVALID_GROUP_ID = -1;

                groupDictionary.TryGetValue(
                    property.PropertyGroupId ?? INVALID_GROUP_ID,
                    out PropertyGroupGetResultDto propertyGroup);

                var propertyDto = property.ToDto();

                propertyDto.Group = propertyGroup;
                propertyDto.PropertyGroupId = propertyGroup?.Id;

                return propertyDto;
            });

            return new CrmObjectTypeSearchResultDto
            {
                Id = viewModel.Id,
                Code = viewModel.Code,
                Enabled = viewModel.IsActive,
                Name = viewModel.Name,
                CrmOjectTypeIndex = viewModel.CrmOjectTypeIndex,
                Description = viewModel.Description,
                Properties = properties,
                Groups = groupDictionary.Values.AsEnumerable(),
                Stages = viewModel.Stages.Select(stage => new StageGetResultDto
                {
                    Name = stage.Name,
                    NameResourceKey = stage.NameResourceKey,
                    Key = stage.Key,
                    IsDoneStage = stage.IsDoneStage,
                    IsActive = stage.IsActive,
                    Index = stage.Index,
                }),
            };
        }

        public static CrmObjectTypeGetRequestVM ConvertToCrmObjectTypeGetRequestVM(this CrmObjectTypeGetRequestDto request)
        {
            return new CrmObjectTypeGetRequestVM { Id = request.Id };
        }



        public static PropertyDefinitionIdWrapper ToVM(this ExtendedPropertyIdWrapperDto dto)
        {
            return new PropertyDefinitionIdWrapper { Id = dto.Id };
        }




    }
}
