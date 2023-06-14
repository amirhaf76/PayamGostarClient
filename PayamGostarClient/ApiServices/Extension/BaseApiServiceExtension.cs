using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class BaseApiServiceExtension
    {
        public static ResourceValueDto ConvertToResourceValueDto(this ResourceValue resourceValue)
        {
            return new ResourceValueDto { Value = resourceValue.Value, LanguageCulture = resourceValue.LanguageCulture };
        }

        public static SystemResourceValueVM ToSystemResourceValueVM(this SystemResourceValueDto systemRecource)
        {
            return new SystemResourceValueVM
            {
                ResourceKey = systemRecource.ResourceKey,
                ResourceValues = systemRecource.ResourceValues.Select(r => r.ToDto()),
            };
        }

        public static LocalizedResourceValueDto ToDto(this ResourceValueDto resource)
        {
            return new LocalizedResourceValueDto { Value = resource.Value, LanguageCulture = resource.LanguageCulture };
        }

        public static LocalizedResourceDto ToLocalizedResourceDto(this SystemResourceValueDto resource)
        {
            return new LocalizedResourceDto { ResourceKey = resource.ResourceKey, ResourceValues = resource.ResourceValues.Select(r => r.ToDto()) };
        }

        public static PropertyGroupGetResultDto ConvertToPropertyGroupGetResultDto(this CrmObjectPropertyGroupGetResultVM group)
        {
            return new PropertyGroupGetResultDto
            {
                Name = group.Name,
                CountOfColumns = group.CountOfColumns,
                ExpandForView = group.ExpandForView,
                NameResourceKey = group.NameResourceKey,
                Id = group.Id,
            };

        }

        public static StageGetResultDto ConvertToStageGetResultDto(this CrmObjectTypeStageGetResultVM stage)
        {
            return new StageGetResultDto
            {
                NameResourceKey = stage.NameResourceKey,
                Name = stage.Name,
                IsActive = stage.IsActive,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
            };
        }

        public static ExtendedPropertyGetResultDto ConvertToExtendedPropertyGetResultDto(this PropertyDefinitionGetResultVM extendedProperty)
        {
            return new ExtendedPropertyGetResultDto
            {
                Name = extendedProperty.Name,
                NameResourceKey = extendedProperty.NameResourceKey,
                Tooltip = extendedProperty.Tooltip,
                TooltipResourceKey = extendedProperty.TooltipResourceKey,
                UserKey = extendedProperty.UserKey,
                PropertyGroupId = extendedProperty.PropertyGroupId,
            };
        }

        public static CrmObjectTypeResultDto ConvertToCrmObjectTypeResultDto(this CrmObjectTypeResultVM vmResult)
        {
            return new CrmObjectTypeResultDto { Id = vmResult.Id };
        }

        public static PropertyDefinitionCreationResultDto ToDto(this PropertyDefinitionPostResultVM result)
        {
            return new PropertyDefinitionCreationResultDto
            {
                Id = result.Id,
            };
        }


        public static TTo CopyFromBaseCrmObjectTypeGetResultVM<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeGetResultDto
            where TFrom : BaseCrmObjectTypeGetResultVM
        {
            to.CrmOjectTypeIndex = from.CrmOjectTypeIndex;
            to.Code = from.Code;
            to.Name = from.Name;
            to.Description = from.Description;

            to.Stages = from.Stages.Select(s => s.ConvertToStageGetResultDto());
            to.Groups = from.Groups.Select(g => g.ConvertToPropertyGroupGetResultDto());
            to.Properties = from.Properties.Select(p =>
            {
                var theProperty = p.ConvertToExtendedPropertyGetResultDto();

                theProperty.Group = to.Groups.Where(g => g.Id == theProperty.PropertyGroupId).FirstOrDefault();

                return theProperty;
            });

            return to;
        }

        public static TTo CopyFromBaseCrmObjectTypeCreateRequestDto<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeCreateRequestVM
            where TFrom : BaseCrmObjectTypeCreateRequestDto
        {
            to.Code = from.Code;
            to.Name = from.Name.ToSystemResourceValueVM();
            to.Description = from.Description.ToSystemResourceValueVM();
            to.PreviewTypeIndex = from.PreviewTypeIndex;

            return to;
        }

    }
}
