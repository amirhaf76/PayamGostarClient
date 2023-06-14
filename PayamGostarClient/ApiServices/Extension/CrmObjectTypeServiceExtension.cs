using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System.Collections.Generic;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class CrmObjectTypeServiceExtension
    {
        public static CrmObjectTypeSearchRequestVM ConvertToCrmObjectTypeSearchRequestVM(this CrmObjectTypeSearchRequestDto crmModel)
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

        public static CrmObjectTypeSearchResultDto ConvertToCrmObjectTypeSearchResultDto(this CrmObjectTypeGetResultVM viewModel)
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
                });
            }

            var properties = viewModel.Properties.Select(property =>
            {
                const int INVALID_GROUP_ID = -1;

                groupDictionary.TryGetValue(
                    property.PropertyGroupId ?? INVALID_GROUP_ID,
                    out PropertyGroupGetResultDto propertyGroup);

                return new ExtendedPropertyGetResultDto
                {
                    UserKey = property.UserKey,
                    Name = property.Name,
                    NameResourceKey = property.NameResourceKey,
                    Tooltip = property.Tooltip,
                    TooltipResourceKey = property.TooltipResourceKey,
                    Group = propertyGroup,
                };
            });

            return new CrmObjectTypeSearchResultDto
            {
                Id = viewModel.Id,
                Code = viewModel.Code,
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
                }),
            };
        }

        public static CrmObjectTypeGetRequestVM ConvertToCrmObjectTypeGetRequestVM(this CrmObjectTypeGetRequestDto request)
        {
            return new CrmObjectTypeGetRequestVM { Id = request.Id };
        }

        public static ExtendedPropertySearchRequestDto ConvertToBaseExtendedPropertySearchRequestDto(this BaseExtendedPropertyModel property)
        {
            return new ExtendedPropertySearchRequestDto
            {
                Name = property.Name.Select(n => n.ConvertToResourceValueDto()),
                ToolTip = property.ToolTip.Select(tp => tp.ConvertToResourceValueDto()),
                UserKey = property.UserKey
            };
        }

        public static PropertyGroupSearchRequestDto ConvertTPropertyGroupSearchRequestDto(this PropertyGroup propertyGroup)
        {
            return new PropertyGroupSearchRequestDto
            {
                Name = propertyGroup.Name.Select(n => n.ConvertToResourceValueDto()),
                CountOfColumns = propertyGroup.CountOfColumns,
                Expanded = propertyGroup.Expanded,
            };
        }

        public static StageSearchRequestDto ConvertToStageSearchRequestDto(this Stage stage)
        {
            return new StageSearchRequestDto
            {
                Name = stage.Name.Select(n => n.ConvertToResourceValueDto()),
                Enabled = stage.Enabled,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
            };
        }

        public static PropertyDefinitionIdWrapper ToVM(this ExtendedPropertyIdWrapperDto dto)
        {
            return new PropertyDefinitionIdWrapper { Id = dto.Id };
        }




    }
}
