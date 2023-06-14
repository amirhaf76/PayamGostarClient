using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Abstractions;
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

        private async Task CreateCrmObjectTypeBelongs(Guid Id)
        {
            // await CreateGroupPropetiesAsync(Id);

            await CreateExtendedPropertiesAsync(Id);

            // await CreateStagesAsync(Id);
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

            return CreateSearchedCrmObjectModel(receivedCrmObject);
        }

        private static CrmObjectTypeSearchRequestDto ConvertToCrmObjectTypeSearchRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                Code = crmMode.Code,
                CrmOjectTypeIndex = (int)crmMode.Type,
                Name = crmMode.Name.FirstOrDefault()?.Value,
                PageSiz = 10,
                PageNumber = 1,
            };
        }


        private async Task<Guid> CreateCrmObjectAsync()
        {
            return await CreateTypeAsync();
        }

        private Task CreateStagesAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        private Task CreateGroupPropetiesAsync(Guid Id)
        {
            throw new NotImplementedException();
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

        private SearchedCrmObjectModel CreateSearchedCrmObjectModel(CrmObjectTypeSearchResultDto receivedCrmObject)
        {
            if (receivedCrmObject == null)
            {
                return null;
            }

            return receivedCrmObject.ToSearchedCrmObjectModel();
        }
    }


}
