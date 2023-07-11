using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;
using System.Linq;

namespace PayamGostarClient.Initializer.Utilities.Extensions
{
    internal static class BaseInitServiceExtension
    {
        internal static string LanguageCulture { get; set; } = "fa-IR";

        internal static TTarget FillBaseCrmObjectTypeCreateRequestDto<TFrom, TTarget>(this TTarget target, TFrom from)
            where TTarget : BaseCrmObjectTypeCreateRequestDto
            where TFrom : BaseCRMModel
        {
            target.Name = new SystemResourceValueDto
            {
                ResourceValues = from.Name?.Select(n => n.ToDto())
            };

            target.Description = new SystemResourceValueDto
            {
                ResourceValues = from.Description?.Select(d => d.ToDto())
            };

            target.Code = from.Code;
            target.Enabled = from.Enabled ?? true;
            target.PreviewTypeIndex = (int)from.PreviewTypeIndex;

            target.AssignCustomerNumberOnApprove = from.AssignCustomerNumberOnApprove;
            target.CreateByCustomer = from.CreateByCustomer;
            target.CustomerCanViewExtendedProps = from.CustomerCanViewExtendedProps;
            target.IsUnderProcess = from.IsUnderProcess;
            target.LimitAccessToProcessUsers = from.LimitAccessToProcessUsers;
            target.ShowToCustomer = from.ShowToCustomer;
            target.ViewOnlyToOwner = from.ViewOnlyToOwner;

            target.SortType = from.SortType;
            target.AllowedDeleteDuration = from.AllowedDeleteDuration;
            target.AllowedEditDuration = from.AllowedEditDuration;

            target.WebhookAddress = from.WebhookAddress;
            target.Content = new CrmObjectTypeContentFilePathDto { FilePath = from.ContentFilePath };

            target.EventTypes = from.EventTypes;

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

        internal static CrmObjectTypeStageCreationRequestDto CreateStageCreationRequest(this Stage stage)
        {
            return new CrmObjectTypeStageCreationRequestDto
            {
                CrmObjectTypeId = stage.Id,
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

        internal static Stage ToModel(this StageGetResultDto dto)
        {
            return new Stage
            {
                Id = dto.Id,
                CrmObjectTypeId = dto.CrmObjectTypeId,
                ResouceKey = !string.IsNullOrEmpty(dto.NameResourceKey) ? (Guid?)Guid.Parse(dto.NameResourceKey) : null,
                Name = ToResourceValues(dto.Name),
                Key = dto.Key,
                IsDoneStage = dto.IsDoneStage,
                IsDeleted = dto.IsDeleted,
                Enabled = dto.IsActive,
                Index = dto.Index,
            };
        }


    }
}
