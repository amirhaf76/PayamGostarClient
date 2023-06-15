using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiServices.Dtos.PropertyGroupServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Exceptions;
using PayamGostarClient.InitServiceModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models
{
    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected T IntendedCrmObject { get; }

        protected IPayamGostarClientServiceFactory ServiceFactory { get; }

        protected ICrmObjectTypeService CrmObjectTypeService { get; }
        protected IExtendedPropertyService ExtendedPropertyService { get; }
        protected IPropertyGroupService PropertyGroupService { get; }
        protected ICrmObjectTypeStageService CrmObjectTypeStageService { get; }


        protected BaseInitService(T intendedCrmObject, IPayamGostarClientServiceFactory serviceFactory)
        {
            IntendedCrmObject = intendedCrmObject;

            ServiceFactory = serviceFactory;

            CrmObjectTypeService = ServiceFactory.CreateCrmObjectTypeService();
            ExtendedPropertyService = ServiceFactory.CreateExtendedPropertyService();
            PropertyGroupService = ServiceFactory.CreatePropertyGroupService();
            CrmObjectTypeStageService = ServiceFactory.CreateCrmObjectTypeStageService();
        }

        public async Task InitAsync()
        {
            var existedCrmObject = await SearchCrmObjectAsync();

            if (existedCrmObject == null)
            {
                await CreateCrmObjectAndSetItsBelongsAsync(IntendedCrmObject);
            }
            else
            {
                await CheckCrmObjectTypeBelongs(IntendedCrmObject, existedCrmObject);
            }
        }

        private async Task CreateCrmObjectAndSetItsBelongsAsync(T intendedCrmObject)
        {
            var newCrmObjectId = await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs(newCrmObjectId);
        }

        private async Task CheckCrmObjectTypeBelongs(T intendedCrmObject, SearchedCrmObjectModel existedCrmObject)
        {
            await CheckAndModifyCrmPropertiesAsync();

            await CheckExtendedPropertiesAsync();

            await CheckGroupPropetiesAsync();

            await CheckStagesAsync();
        }

        private async Task CreateCrmObjectTypeBelongs(Guid id)
        {
            await CreateGroupPropetiesAsync(id);

            await CreateExtendedPropertiesAsync(id);

            await CreateStagesAsync(id);
        }


        private async Task CheckStagesAsync()
        {
            if (false)
            {

            }

            await CreateStagesAsync(Guid.Empty);

            throw new NotImplementedException();
        }

        private async Task CheckGroupPropetiesAsync()
        {
            if (false)
            {

            }

            await CreateGroupPropetiesAsync(Guid.Empty);

            throw new NotImplementedException();
        }

        private async Task CheckExtendedPropertiesAsync()
        {
            if (false)
            {

            }

            await CreateExtendedPropertiesAsync(Guid.Empty);

            throw new NotImplementedException();
        }


        private async Task<SearchedCrmObjectModel> SearchCrmObjectAsync()
        {
            var request = ConvertToCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            var receivedCrmObjects = await CrmObjectTypeService.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            if (receivedCrmObject == null)
            {
                return null;
            }

            return receivedCrmObject.ToModel();
        }

        private static CrmObjectTypeSearchRequestDto ConvertToCrmObjectTypeSearchRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                Code = crmMode.Code,
                CrmOjectTypeIndex = (int)crmMode.Type,
                Name = crmMode.Name.FirstOrDefault()?.Value,
            };
        }


        private async Task<Guid> CreateCrmObjectAsync()
        {
            return await CreateTypeAsync();
        }

        private async Task CreateStagesAsync(Guid id)
        {
            var aFinalStage = IntendedCrmObject.Stages.FirstOrDefault(s => s.IsDoneStage == true);

            if (aFinalStage == null)
            {
                throw new NotFoundAtleastAFinalStageException();
            }

            IntendedCrmObject.Stages.Sort(StagePriorityComparer.GetInstance());

            foreach (var stage in IntendedCrmObject.Stages)
            {
                var stageDto = stage.CreateStageCreationRequest(id);

                var stageCreationResult = await CrmObjectTypeStageService.CreateAsync(stageDto);

                stage.Id = stageCreationResult.Result.StageId;
            }
        }

        private async Task CreateGroupPropetiesAsync(Guid id)
        {
            foreach (var group in IntendedCrmObject.PropertyGroups)
            {
                var groupDto = group.CreatePropertyGroupCreationRequest(id);

                var groupCreationResult = await PropertyGroupService.CreateAsync(groupDto);

                group.Id = groupCreationResult.Result.Id;
            }
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id)
        {
            var createdPropertiesId = new List<Guid>();

            foreach (var property in IntendedCrmObject.Properties)
            {
                var propertyDto = CreateExtendedPropertyDto(property);

                propertyDto.CrmObjectTypeId = id;

                var response = await ExtendedPropertyService.CreateAsync(propertyDto);

                createdPropertiesId.Add(response.Result.Id);
            }

            return createdPropertiesId;
        }


        protected abstract Task<Guid> CreateTypeAsync();

        protected abstract Task<T> CheckAndModifyCrmPropertiesAsync();

        private BaseExtendedPropertyCreationDto CreateExtendedPropertyDto(BaseExtendedPropertyModel propertyModel)
        {
            switch (propertyModel.Type)
            {
                case Gp_ExtendedPropertyType.Text:
                    return propertyModel.ToTextExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Form:
                    return propertyModel.ToFormExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.DropDownList:
                    return propertyModel.ToDropDownListExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.User:
                    return propertyModel.ToUserExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Number:
                    return propertyModel.ToNumberExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Department:
                    return propertyModel.ToDepartmentExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Position:
                    return propertyModel.ToPositionExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Date:
                    return propertyModel.ToPersianDateExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Label:
                    return propertyModel.ToLabelExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    return propertyModel.ToCrmObjectMultiValueExtendedPropertyCreationDto();

                default:
                    throw new NotFoundExtendedPropertyTypeException();
            }
        }

        private BaseExtendedPropertyModel CreateExtendedPropertyModel(ExtendedPropertyGetResultDto propertyDto)
        {
            switch ((Gp_ExtendedPropertyType)propertyDto.PropertyDisplayTypeIndex)
            {
                case Gp_ExtendedPropertyType.Text:
                    return propertyDto.ToTextExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.Form:
                    return propertyDto.ToFormExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.DropDownList:
                    return propertyDto.ToDropDownListExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.User:
                    return propertyDto.ToUserExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.Number:
                    return propertyDto.ToNumberExtendedPropertyModel();
                case Gp_ExtendedPropertyType.Department:
                    return propertyDto.ToDepartmentExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.Position:
                    return propertyDto.ToPositionExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.Date:
                    return propertyDto.ToPersianDateExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.Label:
                    return propertyDto.ToLabelExtendedPropertyModel();
                    
                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    return propertyDto.ToCrmObjectMultiValueExtendedPropertyModel();
                    
                default:
                    throw new NotFoundExtendedPropertyTypeException();
            }
        }
        private SearchedCrmObjectModel CreateSearchedCrmObjectModel(CrmObjectTypeSearchResultDto receivedCrmObject)
        {
            return receivedCrmObject.ToModel();
        }
    }


}
