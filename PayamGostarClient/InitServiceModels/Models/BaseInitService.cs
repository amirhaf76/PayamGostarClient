using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
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
            ValidateInitialValidationModel();

            var searchedCrmObject = await SearchCrmObjectAsync();

            if (searchedCrmObject == null)
            {
                await CreateCrmObjectAndSetItsBelongsAsync();
            }
            else
            {
                await CheckCrmObjectTypeBelongs(searchedCrmObject.Id);
            }
        }

        private void ValidateInitialValidationModel()
        {
            if (string.IsNullOrEmpty(IntendedCrmObject.Code))
            {
                throw new CrmCodeIsNullException();
            }
        }

        private async Task CreateCrmObjectAndSetItsBelongsAsync()
        {
            var newCrmObjectId = await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs(newCrmObjectId);
        }

        private async Task CheckCrmObjectTypeBelongs(Guid id)
        {
            var currentCrmObject = await GetCrmObjectTypeAsync(id);

            var newCrmObject = CheckBaseCrmObjectMatching(currentCrmObject);

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
            var request = ToCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            var receivedCrmObjects = await CrmObjectTypeService.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            if (receivedCrmObject == null)
            {
                return null;
            }

            return receivedCrmObject.ToModel();
        }

        private static CrmObjectTypeSearchRequestDto ToCrmObjectTypeSearchRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                Code = crmMode.Code,
                CrmOjectTypeIndex = (int)crmMode.Type,
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

        protected abstract Task<T> GetCrmObjectTypeAsync(Guid id);

        protected abstract T CheckCrmObjectMatching(T currentCrmObj);

        private T CheckBaseCrmObjectMatching(T currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.Type, currentCrmObj.Type);
            CheckFieldMatching(IntendedCrmObject.Code, currentCrmObj.Code);
            CheckFieldMatching(IntendedCrmObject.PreviewTypeIndex, currentCrmObj.PreviewTypeIndex);

            if (!IntendedCrmObject.Name.CheckResourceValues(currentCrmObj.Name))
            {
                throw new MisMatchException();
            }

            if (!IntendedCrmObject.Description.CheckResourceValues(currentCrmObj.Description))
            {
                throw new MisMatchException();
            }

            return CheckCrmObjectMatching(currentCrmObj);
        }


        private IEnumerable<PropertyGroup> CheckGroupPropety(PropertyGroup intendedGroup, IEnumerable<PropertyGroup> currentGroups)
        {
            var unexistedGroup = new List<PropertyGroup>();

            var resourceValueComparer = ResourceValueEqualityComparer.GetInstance();

            foreach (var currentGroup in currentGroups)
            {
                if (intendedGroup.Name.Any(n => currentGroup.Name.Contains(n, resourceValueComparer)))
                {
                    if (!intendedGroup.Name.CheckResourceValues(currentGroup.Name))
                    {
                        throw new MisMatchException();
                    }

                    CheckFieldMatching(intendedGroup.Expanded, currentGroup.Expanded);
                    CheckFieldMatching(intendedGroup.CountOfColumns, currentGroup.CountOfColumns);
                }
                else
                {
                    unexistedGroup.Add(currentGroup);
                }
            }

            return unexistedGroup;
        }

        private IEnumerable<Stage> CheckStage(Stage intendedStage, IEnumerable<Stage> currentStages)
        {
            var unexistedStage = new List<Stage>();

            var resourceValueComparer = ResourceValueEqualityComparer.GetInstance();

            foreach (var currentStage in currentStages)
            {
                if (intendedStage.Name.Any(n => currentStage.Name.Contains(n, resourceValueComparer)))
                {
                    if (!intendedStage.Name.CheckResourceValues(currentStage.Name))
                    {
                        throw new MisMatchException();
                    }

                    CheckFieldMatching(intendedStage.Key, currentStage.Key);
                    CheckFieldMatching(intendedStage.Enabled, currentStage.Enabled);
                    CheckFieldMatching(intendedStage.IsDoneStage, currentStage.IsDoneStage);
                }
                else
                {
                    unexistedStage.Add(currentStage);
                }
            }

            return unexistedStage;
        }


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

        protected static void CheckFieldMatching<TField>(TField first, TField second)
        {
            if (!first.Equals(second))
            {
                throw new MisMatchException($"{first} != {second}");
            }
        }

    }

    public static class ModelChecker
    {
        public static bool CheckResourceValues(this IEnumerable<ResourceValue> first, IEnumerable<ResourceValue> second)
        {
            return first
                .Join(
                    second,
                    outter => outter.LanguageCulture,
                    inner => inner.LanguageCulture,
                    (inner, outter) => new ValueTuple<string, string>(outter.Value, inner.Value))
                .All(join => join.Item1 == join.Item2);
        }
    }


}
