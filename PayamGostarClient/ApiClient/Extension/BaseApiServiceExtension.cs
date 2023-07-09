using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.Initializer.CrmModels;
using System.Linq;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePaymentApiClientDtos.Create;

namespace PayamGostarClient.ApiClient.Extension
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
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
                Index = stage.Index,
            };
        }

        private static ExtendedPropertyExtraConfigDto CastOrDefault(this PropertyDefinitionExtraConfigs config, Enums.Gp_PropertyDisplayType displaytype)
        {
            switch (displaytype)
            {
                case Enums.Gp_PropertyDisplayType.Number:
                    return (config as NumericPropertyDefinitionExtraConfigs)?.ToDto() ?? throw new System.Exception();

                case Enums.Gp_PropertyDisplayType.Label:
                    return (config as LabelPropertyDefinitionExtraConfig)?.ToDto() ?? throw new System.Exception();

                case Enums.Gp_PropertyDisplayType.CrmObjectMultiValue:
                    return (config as CrmObjectMultiValuePropertyDefinitionExtraConfigs)?.ToDto() ?? throw new System.Exception();

                case Enums.Gp_PropertyDisplayType.CrmObject:
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
                ExtraConfig = extendedProperty.ExtraConfiguration.CastOrDefault((Enums.Gp_PropertyDisplayType)extendedProperty.PropertyDisplayTypeIndex),
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


        public static TTo FillBaseCrmObjectTypeGetResultDto<TFrom, TTo>(this TTo to, TFrom from)
            where TTo : BaseCrmObjectTypeGetResultDto
            where TFrom : BaseCrmObjectTypeGetResultVM
        {
            to.CrmOjectTypeIndex = from.CrmOjectTypeIndex;
            to.Code = from.Code;
            to.Enabled = from.IsActive;
            to.Name = from.Name;
            to.Description = from.Description;

            to.Stages = from.Stages?.Select(s => ToDto(s));
            to.Groups = from.Groups?.Select(g => g.ToDto());
            to.Properties = from.Properties?.Select(p =>
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
