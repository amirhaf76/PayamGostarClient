using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos;
using PayamGostarClient.ApiServices.Dtos.PropertyGroupServiceDtos;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Linq;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class BaseInitServiceExtension
    {
        internal static string LanguageCulture { get; set; } = "fa-IR";


        internal static TTarget FillBaseCRMModel<TFrom, TTarget>(this TTarget target, TFrom from)
            where TTarget : BaseCRMModel
            where TFrom : BaseCrmObjectTypeGetResultDto
        {
            target.Code = from.Code;
            target.Enabled = from.Enabled;
            target.Name = ToResourceValues(from.Name);
            target.Description = ToResourceValues(from.Description);
            target.Properties = from.Properties?.Select(p => p.ToBaseExtendedPropertyModel()).ToList();
            target.PropertyGroups = from.Groups?.Select(g => g.ToPropertyGroup()).ToList();
            target.Stages = from.Stages?.Select(p => p.ToStage()).ToList();


            return target;
        }

        internal static TTarget FillBaseCrmObjectTypeCreateRequestDto<TFrom, TTarget>(this TTarget target, TFrom from)
            where TTarget : BaseCrmObjectTypeCreateRequestDto
            where TFrom : BaseCRMModel
        {
            target.Name = new SystemResourceValueDto();
            target.Description = new SystemResourceValueDto();

            target.Name.ResourceValues = from.Name.Select(n => n.ToDto());
            target.Description.ResourceValues = from.Description.Select(d => d.ToDto());
            target.Code = from.Code;
            target.Enabled = from.Enabled ?? true;
            target.PreviewTypeIndex = (int)from.PreviewTypeIndex;

            return target;
        }


        // Todo: Warning! using hard code value for Language Culture.
        internal static ResourceValue[] ToResourceValues(string value)
        {
            return new ResourceValue[] { new ResourceValue { Value = value, LanguageCulture = LanguageCulture } };
        }

        internal static PropertyGroup ToPropertyGroup(this PropertyGroupGetResultDto group)
        {
            return new PropertyGroup
            {
                Name = ToResourceValues(group.Name),
                Expanded = group.ExpandForView,
                CountOfColumns = group.CountOfColumns ?? 0,
                Id = group.Id,
                //ResouceKey = (!string.IsNullOrEmpty(group.NameResourceKey)) ? Guid.Parse(group.NameResourceKey) : Guid.Empty,
            };
        }

        internal static BaseExtendedPropertyModel ToBaseExtendedPropertyModel(this ExtendedPropertyGetResultDto property)
        {
            return property.ToModel();
        }

        internal static BaseExtendedPropertyModel FillBaseExtendedPropertyModel<TTarget, TFrom>(this BaseExtendedPropertyModel target, ExtendedPropertyGetResultDto from)
            where TTarget : BaseExtendedPropertyModel
            where TFrom : ExtendedPropertyGetResultDto
        {
            target.UserKey = from.UserKey;
            target.Name = ToResourceValues(from.Name);
            target.ToolTip = ToResourceValues(from.Tooltip);
            target.PropertyGroup = from.Group.ToPropertyGroup();

            return target;
        }

        internal static Stage ToStage(this StageGetResultDto stage)
        {
            return new Stage
            {
                Name = ToResourceValues(stage.Name),
                Enabled = stage.IsActive,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
                Index = stage.Index,
            };
        }

        internal static CrmObjectPropertyGroupCreationRequestDto CreatePropertyGroupCreationRequest(this PropertyGroup group, Guid crmObjectTypeId)
        {
            return new CrmObjectPropertyGroupCreationRequestDto
            {
                CrmObjectTypeId = crmObjectTypeId,
                CountOfColumns = group.CountOfColumns,
                ExpandForView = group.Expanded,
                Name = new SystemResourceValueDto
                {
                    ResourceValues = group.Name.Select(n => n.ToDto())
                }
            };
        }

        internal static CrmObjectTypeStageCreationRequestDto CreateStageCreationRequest(this Stage stage, Guid crmObjectTypeId)
        {
            return new CrmObjectTypeStageCreationRequestDto
            {
                CrmObjectTypeId = crmObjectTypeId,
                Enabled = stage.Enabled,
                Index = stage.Index,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
                Name = new SystemResourceValueDto
                {
                    ResourceKey = stage.ResouceKey?.ToString(),
                    ResourceValues = stage.Name.Select(n => n.ToDto())
                },
            };
        }

        internal static Stage ToModel(this CrmObjectTypeStageGetResultDto dto)
        {
            return new Stage
            {
                Id = dto.Id,
                ResouceKey = !string.IsNullOrEmpty(dto.NameResourceKey) ? (Guid?)Guid.Parse(dto.NameResourceKey) : null,
                Name = ToResourceValues(dto.Name),
                Key = dto.Key,
                IsDoneStage = dto.IsDoneStage,
                Enabled = dto.IsActive,
                Index = dto.Index,
            };
        }


    }
}
