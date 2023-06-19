using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Comparers;
using PayamGostarClient.InitServiceModels.Exceptions;
using PayamGostarClient.InitServiceModels.Extensions;
using PayamGostarClient.InitServiceModels.ModelCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Models.Services
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
                await CheckCrmObjectTypeBelongs(searchedCrmObject);
            }
        }


        private void ValidateInitialValidationModel()
        {
            if (string.IsNullOrEmpty(IntendedCrmObject.Code))
            {
                throw new NullCrmCodeException();
            }

            if (!IntendedCrmObject.Name.Any())
            {
                throw new NullNameException();
            }

            ValidateExtendedProperites();

            ValidateStages();

        }

        private void ValidateStages()
        {
            if (!IntendedCrmObject.Stages.All(s => !string.IsNullOrEmpty(s.Key)))
            {
                throw new NullStageKeyExcpetion();
            }

            var stageKeyGroups = IntendedCrmObject.Stages.GroupBy(s => s.Key);

            foreach (var stageKeyGroup in stageKeyGroups)
            {
                if (stageKeyGroup.Count() > 1)
                {
                    throw new NonUniqeStageKeyException($"There is more than one property with \"{stageKeyGroup.Key}\".");
                }
            }
        }

        private void ValidateExtendedProperites()
        {
            if (!IntendedCrmObject.Properties.All(p => !string.IsNullOrEmpty(p.UserKey)))
            {
                throw new NullPropertyUserKeyExcpetion();
            }

            var propertyKeyGroups = IntendedCrmObject.Properties.GroupBy(p => p.UserKey);

            foreach (var propertyKeyGroup in propertyKeyGroups)
            {
                if (propertyKeyGroup.Count() > 1)
                {
                    throw new NonUniqeUserKeyException($"There is more than one property with \"{propertyKeyGroup.Key}\".");
                }
            }
        }


        private async Task CreateCrmObjectAndSetItsBelongsAsync()
        {
            var newCrmObjectId = await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs(newCrmObjectId);
        }

        private async Task CheckCrmObjectTypeBelongs(CrmObjectTypeSearchResultDto currentCrmObject)
        {
            CheckBaseCrmObjectMatching(currentCrmObject);

            await CheckGroupPropertiesAndCreateUnexistedGroupPropetiesAsync(currentCrmObject.Id, currentCrmObject.Groups?.Select(g => g.ToPropertyGroup()));

            await CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(currentCrmObject.Id, currentCrmObject.Properties?.Select(x => x.ToBaseExtendedPropertyModel()));

            await CheckStagesAndUpdateUnexistedStagesAsync(currentCrmObject.Id, currentCrmObject.Stages?.Select(x => x.ToStage()));
        }

        private async Task CreateCrmObjectTypeBelongs(Guid id)
        {
            await CreateGroupPropetiesAsync(id);

            await CreateExtendedPropertiesAsync(id);

            await CreateStagesAsync(id);
        }


        private async Task CheckStagesAndUpdateUnexistedStagesAsync(Guid id, IEnumerable<Stage> currentStages)
        {
            var detectedPair = IntendedCrmObject.Stages.Join(
                currentStages,
                intendedStage => intendedStage.Key,
                currentStage => currentStage.Key,
                (intendedStage, currentStage) => Tuple.Create(intendedStage, currentStage)
                );

            foreach (var pair in detectedPair)
            {
                CheckFieldMatching(pair.Item1.IsDoneStage, pair.Item2.IsDoneStage, "CheckingStage:IsDoneStage -> ");
            }

            var newStages = IntendedCrmObject.Stages
                .Except(detectedPair.Select(d => d.Item1))
                .ToList();

            await UpdateStagesAsync(id, newStages);
        }

        private async Task CheckGroupPropertiesAndCreateUnexistedGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups)
        {
            var newGroups = new List<PropertyGroup>();

            foreach (var group in IntendedCrmObject.PropertyGroups)
            {
                var newGroup = CheckGroupPropetyAndUpdateIdIfExists(group, groups);

                if (!newGroup.found)
                {
                    newGroups.Add(newGroup.group);
                }
            }

            await CreateGroupPropetiesAsync(id, newGroups);
        }

        private async Task CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> currentExtendedProperties)
        {
            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(currentExtendedProperties);

            await CreateExtendedPropertiesAsync(id, newProperties);
        }


        private async Task<CrmObjectTypeSearchResultDto> SearchCrmObjectAsync()
        {
            var request = ToCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            Helper.Net.ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>> receivedCrmObjects = await CrmObjectTypeService.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            return receivedCrmObject;
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
            await CreateStagesAsync(id, IntendedCrmObject.Stages);
        }

        private async Task CreateStagesAsync(Guid id, List<Stage> stages)
        {
            if (!stages.Any())
            {
                return;
            }

            var aFinalStage = stages.FirstOrDefault(s => s.IsDoneStage == true);

            if (aFinalStage == null)
            {
                throw new NotFoundAtleastAFinalStageException();
            }

            stages.Sort(StagePriorityComparer.GetInstance());

            foreach (var stage in stages)
            {
                await CreateStageAsync(id, stage);
            }
        }

        private async Task UpdateStagesAsync(Guid id, List<Stage> stages)
        {
            if (!stages.Any())
            {
                return;
            }

            stages.Sort(StagePriorityComparer.GetInstance());

            foreach (var stage in stages)
            {
                await CreateStageAsync(id, stage);
            }
        }

        private async Task CreateStageAsync(Guid id, Stage stage)
        {
            var stageDto = stage.CreateStageCreationRequest(id);

            var stageCreationResult = await CrmObjectTypeStageService.CreateAsync(stageDto);

            stage.Id = stageCreationResult.Result.StageId;
        }


        private async Task CreateGroupPropetiesAsync(Guid id)
        {
            await CreateGroupPropetiesAsync(id, IntendedCrmObject.PropertyGroups);
        }

        private async Task CreateGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups)
        {
            foreach (var group in groups)
            {
                await CreateGroupPropetiesAsync(id, group);
            }
        }

        private async Task CreateGroupPropetiesAsync(Guid id, PropertyGroup group)
        {
            var groupDto = group.CreatePropertyGroupCreationRequest(id);

            var groupCreationResult = await PropertyGroupService.CreateAsync(groupDto);

            group.Id = groupCreationResult.Result.Id;
        }


        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id)
        {
            return await CreateExtendedPropertiesAsync(id, IntendedCrmObject.Properties);
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties)
        {
            var createdPropertiesId = new List<Guid>();

            foreach (var property in properties)
            {
                property.CrmObjectTypeId = id.ToString();

                var propertyDto = CreateExtendedPropertyCreationDto(property);

                var response = await ExtendedPropertyService.CreateAsync(propertyDto);

                createdPropertiesId.Add(response.Result.Id);
            }

            return createdPropertiesId;
        }


        private void CheckBaseCrmObjectMatching(CrmObjectTypeSearchResultDto currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.Type, (Gp_CrmObjectType)currentCrmObj.CrmOjectTypeIndex, "BaseCrmObj:Type -> ");
            CheckFieldMatching(IntendedCrmObject.Code, currentCrmObj.Code, "BaseCrmObj:Code -> ");
        }


        protected abstract Task<Guid> CreateTypeAsync();


        private (PropertyGroup group, bool found) CheckGroupPropetyAndUpdateIdIfExists(PropertyGroup intendedGroup, IEnumerable<PropertyGroup> currentGroups)
        {
            var resourceValueComparer = ResourceValueEqualityComparer.GetInstance();

            foreach (var currentGroup in currentGroups)
            {
                if (intendedGroup.Name.Any(n => currentGroup.Name.Contains(n, resourceValueComparer)))
                {
                    if (!intendedGroup.Name.CheckResourceValues(currentGroup.Name))
                    {
                        return (intendedGroup, false);
                    }


                    intendedGroup.Id = currentGroup.Id;

                    return (intendedGroup, true);
                }
            }

            return (intendedGroup, false);
        }

        private IEnumerable<BaseExtendedPropertyModel> CheckExtendedPropertiesAndGetUnexistedExtendedProperties(IEnumerable<BaseExtendedPropertyModel> currentProperties)
        {
            var detectedPair = IntendedCrmObject.Properties.Join(
                currentProperties,
                intendedProperty => intendedProperty.UserKey,
                currentProperty => currentProperty.UserKey,
                (intendedProperty, currentProperty) => Tuple.Create(intendedProperty, currentProperty)
                );

            foreach (var pair in detectedPair)
            {
                CheckExtendedProperty(pair.Item1, pair.Item2);
            }

            return IntendedCrmObject.Properties.Except(detectedPair.Select(d => d.Item1));
        }

        private void CheckExtendedProperty(BaseExtendedPropertyModel item1, BaseExtendedPropertyModel item2)
        {
            new GeneralExtendedPropertyModelEqualityComparer().Checks(item1, item2);
        }

        private BaseExtendedPropertyCreationDto CreateExtendedPropertyCreationDto(BaseExtendedPropertyModel propertyModel)
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


                case Gp_ExtendedPropertyType.Time:
                    return propertyModel.ToTimeExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Currency:
                    return propertyModel.ToCurrencyExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.File:
                    return propertyModel.ToFileExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Checkbox:
                    return propertyModel.ToCheckboxExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.Appointment:
                    return propertyModel.ToAppointmentExtendedPropertyCreationDto();

                case Gp_ExtendedPropertyType.SecurityItem:
                    return propertyModel.ToSecurityItemExtendedPropertyCreationDto();


                default:
                    throw new NotFoundExtendedPropertyTypeException();
            }
        }

        protected void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            ModelChecker.CheckFieldMatching(first, second, errorMessage);
        }

    }
}
