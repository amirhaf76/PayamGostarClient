using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.Initializer.CrmModels;
using System.Linq;

namespace PayamGostarClient.ApiClient.Extension
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
                Index = stage.Index,
            };
        }

        private static ExtendedPropertyExtraConfigDto CastOrDefault(this PropertyDefinitionExtraConfigs config, Dtos.Gp_PropertyDisplayType displaytype)
        {
            switch (displaytype)
            {
                case Dtos.Gp_PropertyDisplayType.Number:
                    return (config as NumericPropertyDefinitionExtraConfigs)?.ToDto() ?? throw new System.Exception();

                case Dtos.Gp_PropertyDisplayType.Label:
                    return (config as LabelPropertyDefinitionExtraConfig)?.ToDto() ?? throw new System.Exception();

                case Dtos.Gp_PropertyDisplayType.CrmObjectMultiValue:
                    return (config as CrmObjectMultiValuePropertyDefinitionExtraConfigs)?.ToDto() ?? throw new System.Exception();

                case Dtos.Gp_PropertyDisplayType.CrmObject:
                    return (config as CrmObjectReferencedTypeExteraConfigs)?.ToDto() ?? throw new System.Exception();

                default:
                    break;
            }

            return null;
        }
        
        public static ExtendedPropertyGetResultDto ToDto(this PropertyDefinitionGetResultVM extendedProperty)
        {
            return new ExtendedPropertyGetResultDto
            {
                Id = extendedProperty.Id,
                CrmObjectTypeId = extendedProperty.CrmObjectTypeId,
                Name = extendedProperty.Name,
                NameResourceKey = extendedProperty.NameResourceKey,
                Tooltip = extendedProperty.Tooltip,
                TooltipResourceKey = extendedProperty.TooltipResourceKey,
                UserKey = extendedProperty.UserKey,
                PropertyGroupId = extendedProperty.PropertyGroupId,
                PropertyDisplayTypeIndex = extendedProperty.PropertyDisplayTypeIndex,
                DefaultValue = extendedProperty.DefaultValue,
                IsRequired = extendedProperty.IsRequired,
                ExtraConfig = extendedProperty.ExtraConfiguration.CastOrDefault((Dtos.Gp_PropertyDisplayType)extendedProperty.PropertyDisplayTypeIndex),
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


        public static TTo FillBaseCrmObjectTypeGetResultDto<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeGetResultDto
            where TFrom : BaseCrmObjectTypeGetResultVM
        {
            to.CrmOjectTypeIndex = from.CrmOjectTypeIndex;
            to.Code = from.Code;
            to.Enabled = from.IsActive;
            to.Name = from.Name;
            to.Description = from.Description;

            to.Stages = from.Stages.Select(s => s.ConvertToStageGetResultDto());
            to.Groups = from.Groups.Select(g => g.ConvertToPropertyGroupGetResultDto());
            to.Properties = from.Properties.Select(p =>
            {
                var theProperty = p.ToDto();

                theProperty.Group = to.Groups.Where(g => g.Id == theProperty.PropertyGroupId).FirstOrDefault();

                return theProperty;
            });

            return to;
        }

        public static TTo FillBaseCrmObjectTypeCreateRequestVM<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeCreateRequestVM
            where TFrom : BaseCrmObjectTypeCreateRequestDto
        {
            to.Code = from.Code;
            to.Name = from.Name.ToSystemResourceValueVM();
            to.Description = from.Description.ToSystemResourceValueVM();
            to.PreviewTypeIndex = from.PreviewTypeIndex;
            to.IsActive = from.Enabled;

            return to;
        }

    }
}
