using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using SeptaPay.PayamGostarClient.RestApi;
using System.Linq;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    public static class BaseApiServiceExtension
    {
        public static SystemResourceValueVM ToSystemResourceValueVM(this SystemResourceValueDto systemRecource)
        {
            return new SystemResourceValueVM
            {
                ResourceKey = systemRecource.ResourceKey,
                ResourceValues = systemRecource.ResourceValues.Select(r => r.ToDto()),
            };
        }

        public static LocalizedResourceDto ToLocalizedResourceDto(this SystemResourceValueDto resource)
        {
            return new LocalizedResourceDto { ResourceKey = resource.ResourceKey, ResourceValues = resource.ResourceValues.Select(r => r.ToDto()) };
        }


        public static LocalizedResourceValueDto ToDto(this ResourceValueDto resource)
        {
            return new LocalizedResourceValueDto { Value = resource.Value, LanguageCulture = resource.LanguageCulture };
        }

        public static PropertyGroupGetResultDto ToDto(this CrmObjectPropertyGroupGetResultVM group)
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

        public static StageGetResultDto ToDto(this CrmObjectTypeStageGetResultVM stage)
        {
            return new StageGetResultDto
            {
                NameResourceKey = stage.NameResourceKey,
                Name = stage.Name,
                Id = stage.Id,
                CrmObjectTypeId = stage.CrmObjectTypeId,
                IsActive = stage.IsActive,
                IsDeleted = stage.IsDeleted,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
                Index = stage.Index,
            };
        }

        private static ExtendedPropertyExtraConfigDto CastOrDefault(this PropertyDefinitionExtraConfigs config, Core.APIs.Enums.Gp_PropertyDisplayType displaytype)
        {
            switch (displaytype)
            {
                case Core.APIs.Enums.Gp_PropertyDisplayType.Number:
                    return (config as NumericPropertyDefinitionExtraConfigs)?.ToDto() ?? throw new System.Exception();

                case Core.APIs.Enums.Gp_PropertyDisplayType.Label:
                    return (config as LabelPropertyDefinitionExtraConfig)?.ToDto() ?? throw new System.Exception();

                case Core.APIs.Enums.Gp_PropertyDisplayType.CrmObjectMultiValue:
                    return (config as CrmObjectMultiValuePropertyDefinitionExtraConfigs)?.ToDto() ?? throw new System.Exception();

                case Core.APIs.Enums.Gp_PropertyDisplayType.CrmObject:
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
                CrmObjectTypeId = extendedProperty.CrmObjectTypeId,
                DefaultValue = extendedProperty.DefaultValue,
                Id = extendedProperty.Id,
                IsRequired = extendedProperty.IsRequired,
                Name = extendedProperty.Name,
                NameResourceKey = extendedProperty.NameResourceKey,
                ParentId = extendedProperty.ParentId,
                PropertyDisplayIndex = extendedProperty.PropertyDisplayIndex,
                PropertyDisplayTypeIndex = extendedProperty.PropertyDisplayTypeIndex,
                PropertyDisplayTypeName = extendedProperty.PropertyDisplayTypeName,
                PropertyGroupId = extendedProperty.PropertyGroupId,
                PropertyGroupName = extendedProperty.PropertyGroupName,
                PropertyGroupNameResourceKey = extendedProperty.PropertyGroupNameResourceKey,
                PropertyTypeIndex = extendedProperty.PropertyTypeIndex,
                PropertyTypeName = extendedProperty.PropertyTypeName,
                Tooltip = extendedProperty.Tooltip,
                TooltipResourceKey = extendedProperty.TooltipResourceKey,
                UserKey = extendedProperty.UserKey,

                ExtraConfig = extendedProperty.ExtraConfiguration.CastOrDefault((Core.APIs.Enums.Gp_PropertyDisplayType)(Gp_PropertyDisplayType)extendedProperty.PropertyDisplayTypeIndex),
            };
        }

        public static CrmObjectTypeResultDto ToDto(this CrmObjectTypeResultVM vmResult)
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

        public static CrmObjectTypeSignatureFilePathVM ToVM(this CrmObjectTypeSignatureFilePathDto dto)
        {
            return new CrmObjectTypeSignatureFilePathVM { FilePath = dto.FilePath };
        }

        public static CrmObjectTypeSignatureFilePathDto ToDto(this CrmObjectTypeSignatureFilePathVM vm)
        {
            return new CrmObjectTypeSignatureFilePathDto { FilePath = vm.FilePath };
        }


        public static TTo FillBaseCrmObjectTypeGetResultDto<TFrom, TTo>(this TTo target, TFrom from)
            where TTo : BaseCrmObjectTypeGetResultDto
            where TFrom : BaseCrmObjectTypeGetResultVM
        {
            target.AllowedDeleteDuration = from.AllowedDeleteDuration;
            target.AllowedEditDuration = from.AllowedEditDuration;
            target.Code = from.Code;
            target.ContentFileId = from.ContentFileId;
            target.ContentTypeIndex = from.ContentTypeIndex;
            target.ContentTypeName = from.ContentTypeName;
            target.CreateByCustomer = from.CreateByCustomer;
            target.CrmObjectTypeName = from.CrmObjectTypeName;
            target.CrmOjectTypeIndex = from.CrmOjectTypeIndex;
            target.CustomerCanViewExtendedProps = from.CustomerCanViewExtendedProps;
            target.DefaultRelatedToIdentityTypeId = from.DefaultRelatedToIdentityTypeId;
            target.Description = from.Description;
            target.DescriptionResourceKey = from.DescriptionResourceKey;
            target.Enabled = from.IsActive;
            target.EventTypes = from.EventTypes;
            target.Id = from.Id;
            target.IsAbstract = from.IsAbstract;
            target.IsActive = from.IsActive;
            target.IsBillable = from.IsBillable;
            target.IsUnderProcess = from.IsUnderProcess;
            target.LimitAccessToProcessUsers = from.LimitAccessToProcessUsers;
            target.Name = from.Name;
            target.NameResourceKey = from.NameResourceKey;
            target.OwnerId = from.OwnerId;
            target.ParentId = from.ParentId;
            target.PreviewTypeIndex = from.PreviewTypeIndex;
            target.PreviewTypeName = from.PreviewTypeName;
            target.RankPropertyId = from.RankPropertyId;
            target.ShowToCustomer = from.ShowToCustomer;
            target.SortType = from.SortType;
            target.ViewOnlyToOwner = from.ViewOnlyToOwner;
            target.WebhookAddress = from.WebhookAddress;

            target.Stages = from.Stages?.Select(s => s.ToDto());
            target.Groups = from.Groups?.Select(g => g.ToDto());
            target.Properties = from.Properties?.Select(p =>
            {
                var theProperty = p.ToDto();

                theProperty.Group = target.Groups.Where(g => g.Id == theProperty.PropertyGroupId).FirstOrDefault();

                return theProperty;
            });

            return target;
        }

        public static TTo FillBaseCrmObjectTypeCreateRequestVM<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeCreateRequestVM
            where TFrom : BaseCrmObjectTypeCreateRequestDto
        {
            to.AllowedDeleteDuration = from.AllowedDeleteDuration;
            to.AllowedEditDuration = from.AllowedEditDuration;
            to.AssignCustomerNumberOnApprove = from.AssignCustomerNumberOnApprove;
            to.Code = from.Code;
            to.Content = from.Content?.ToVM();
            to.CreateByCustomer = from.CreateByCustomer;
            to.CustomerCanViewExtendedProps = from.CustomerCanViewExtendedProps;
            to.DefaultRelatedToIdentityTypeId = from.DefaultRelatedToIdentityTypeId;
            to.Description = from.Description?.ToSystemResourceValueVM();
            to.EventTypes = from.EventTypes?.Select(x => (WebhookEventType)x);
            to.IsActive = from.Enabled;
            to.IsUnderProcess = from.IsUnderProcess;
            to.LimitAccessToProcessUsers = from.LimitAccessToProcessUsers;
            to.Name = from.Name?.ToSystemResourceValueVM();
            to.OwnerId = from.OwnerId;
            to.PreviewTypeIndex = from.PreviewTypeIndex;
            to.ShowToCustomer = from.ShowToCustomer;
            to.SortType = from.SortType;
            to.ViewOnlyToOwner = from.ViewOnlyToOwner;
            to.WebhookAddress = from.WebhookAddress;

            return to;
        }



        public static CrmObjectTypeContentFilePathVM ToVM(this CrmObjectTypeContentFilePathDto dto)
        {
            return new CrmObjectTypeContentFilePathVM { FilePath = dto.FilePath };
        }

    }
}
