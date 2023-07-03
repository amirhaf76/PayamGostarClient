using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.Comparers;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Extensions;
using PayamGostarClient.Initializer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public abstract class BaseInitService<T> : IInitService where T : BaseCRMModel
    {
        protected T IntendedCrmObject { get; }

        private IPayamGostarCustomizationApiClient CustomizationApi { get; }

        protected IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi { get; }
        protected IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi { get; }
        protected IPayamGostarPropertyGroupApiClient PropertyGroupApi { get; }


        protected BaseInitService(T intendedCrmObject, IPayamGostarApiClient payamGostarApiClient)
        {
            IntendedCrmObject = intendedCrmObject;

            CustomizationApi = payamGostarApiClient.CustomizationApi;

            CrmObjectTypeApi = CustomizationApi.CrmObjectTypeApi;
            ExtendedPropertyApi = CustomizationApi.ExtendedPropertyApi;
            PropertyGroupApi = CustomizationApi.PropertyGroupApi;
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
                await CheckCrmObjectTypeBelongsAndInsert(searchedCrmObject);
            }
        }


        private void ValidateInitialValidationModel()
        {
            if (string.IsNullOrWhiteSpace(IntendedCrmObject.Code))
            {
                throw new NullCrmCodeException($"CrmObjectModel must have a unique code!");
            }

            if (!IntendedCrmObject.Name.Any())
            {
                throw new EmptyNameException($"A CrmObject model with '{IntendedCrmObject.Code}' code doesn't have any names!");
            }

            ValidateExtendedProperites();

            ValidateStages();

        }

        private void ValidateStages()
        {
            if (!IntendedCrmObject.Stages.All(s => !string.IsNullOrWhiteSpace(s.Key)))
            {
                throw new NullStageKeyExcpetion("CrmObjectModel stage must have a key!");
            }

            var stageKeyGroups = IntendedCrmObject.Stages.GroupBy(s => s.Key);

            foreach (var stageKeyGroup in stageKeyGroups)
            {
                if (stageKeyGroup.Count() > 1)
                {
                    throw new NonUniqeStageKeyException($"In the crmObject with '{IntendedCrmObject.Code}', there are more than one stage with '{stageKeyGroup.Key}'!");
                }
            }
        }

        private void ValidateExtendedProperites()
        {
            if (
                (IntendedCrmObject.Properties?.Any() ?? false) &&
                (IntendedCrmObject.PropertyGroups == null || !IntendedCrmObject.PropertyGroups.Any()))
            {
                throw new InvalidGroupCountException($"The crmObject with '{IntendedCrmObject.Code}' needs atleast a group for its extended properties.");
            }

            if (!IntendedCrmObject.Properties?.All(p => p.PropertyGroup != null) ?? false)
            {
                var errorMessage = IntendedCrmObject.Properties
                    .Where(p => p.PropertyGroup == null)
                    .Select(p => p.UserKey);

                throw new UnBindedExtendedPropertyToGroupPropertyException($"Some properties are not binded to a group. their userkeys are: {errorMessage}");
            }

            if (!IntendedCrmObject.Properties?.All(p => !string.IsNullOrEmpty(p.UserKey)) ?? false)
            {
                var errorMessage = IntendedCrmObject.Properties
                    .Where(p => string.IsNullOrEmpty(p.UserKey))
                    .Select(p => p.Name.FirstOrDefault().Value);

                throw new NullPropertyUserKeyExcpetion($"Some properties don't have userkey. their first names are: {errorMessage}");
            }

            var propertyKeyGroups = IntendedCrmObject.Properties.GroupBy(p => p.UserKey);

            foreach (var propertyKeyGroup in propertyKeyGroups)
            {
                if (propertyKeyGroup.Count() > 1)
                {
                    throw new NonUniqeUserKeyException($"In the crmObject with '{IntendedCrmObject.Code}', there are more than one userKey with \"{propertyKeyGroup.Key}\".");
                }
            }
        }


        private async Task CreateCrmObjectAndSetItsBelongsAsync()
        {
            var newCrmObjectId = await CreateCrmObjectAsync();

            await CreateCrmObjectTypeBelongs(newCrmObjectId);
        }

        private async Task CheckCrmObjectTypeBelongsAndInsert(CrmObjectTypeSearchResultDto currentCrmObject)
        {
            CheckBaseCrmObjectMatching(currentCrmObject);

            await CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(currentCrmObject.Id, currentCrmObject.Properties, currentCrmObject.Groups);

            await CheckStagesAndUpdateUnexistedStagesAsync(currentCrmObject.Id, currentCrmObject.Stages?.Select(x => x.ToStage()));
        }

        public void CheckCrmObjectTypeBelongs(CrmObjectTypeSearchResultDto currentCrmObject)
        {
            CheckBaseCrmObjectMatching(currentCrmObject);

            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(currentCrmObject.Properties);

            if (newProperties.Any())
            {
                throw new MisMatchException("There are some new properties.");
            }

            var newStages = CheckStagesAndGetNewStages(currentCrmObject.Stages?.Select(x => x.ToStage()));

            if (newStages.Any())
            {
                throw new MisMatchException("There are some new stages.");
            }
        }

        private async Task CreateCrmObjectTypeBelongs(Guid id)
        {
            await CreateGroupPropetiesAsync(id);

            await CreateExtendedPropertiesAsync(id);

            await CreateStagesAsync(id);
        }


        private async Task CheckStagesAndUpdateUnexistedStagesAsync(Guid id, IEnumerable<Stage> currentStages)
        {
            List<Stage> newStages = CheckStagesAndGetNewStages(currentStages);

            await UpdateStagesAsync(id, newStages);
        }

        private List<Stage> CheckStagesAndGetNewStages(IEnumerable<Stage> currentStages)
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

            return newStages;
        }


        private async Task CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(Guid id, IEnumerable<ExtendedPropertyGetResultDto> currentExtendedProperties, IEnumerable<PropertyGroupGetResultDto> groups)
        {
            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(currentExtendedProperties);

            await CreateExtendedPropertiesAsync(id, newProperties, groups);
        }


        private async Task<CrmObjectTypeSearchResultDto> SearchCrmObjectAsync()
        {
            var request = ToCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            Helper.Net.ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>> receivedCrmObjects = await CrmObjectTypeApi.SearchAsync(request);

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
                throw new NotFoundAtleastAFinalStageException($"In creation of crm object type, final stage is mandatory! the invalid crmObject has '{IntendedCrmObject.Code}' code.");
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

            var stageCreationResult = await CrmObjectTypeApi.StageApi.CreateAsync(stageDto);

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
                var gId = await CreateGroupPropetiesAsync(id, group);

                group.Id = gId;
            }
        }

        private async Task<int> CreateGroupPropetiesAsync(Guid id, PropertyGroup group)
        {
            var groupDto = group.CreatePropertyGroupCreationRequest(id);

            var groupCreationResult = await PropertyGroupApi.CreateAsync(groupDto);

            return groupCreationResult.Result.Id;
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

                var response = await ExtendedPropertyApi.CreateAsync(propertyDto);

                createdPropertiesId.Add(response.Result.Id);
            }

            return createdPropertiesId;
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties, IEnumerable<PropertyGroupGetResultDto> groups)
        {
            var createdPropertiesId = new List<Guid>();

            foreach (var property in properties)
            {
                property.CrmObjectTypeId = id.ToString();

                //fetch group by name
                var group = groups.Where(g => property.PropertyGroup.Name.Any(xx => xx.Value == g.Name)).FirstOrDefault();
                if (group == null)
                {
                    // create group if not exist
                    var gId = await CreateGroupPropetiesAsync(id, property.PropertyGroup);
                    property.PropertyGroup.Id = gId;
                }
                else
                {
                    property.PropertyGroup.Id = group.Id;
                }

                var propertyDto = CreateExtendedPropertyCreationDto(property);

                var response = await ExtendedPropertyApi.CreateAsync(propertyDto);

                createdPropertiesId.Add(response.Result.Id);
            }

            return createdPropertiesId;
        }


        private void CheckBaseCrmObjectMatching(CrmObjectTypeSearchResultDto currentCrmObj)
        {
            CheckFieldMatching(IntendedCrmObject.Code, currentCrmObj.Code, "BaseCrmObj:Code -> ");
            CheckFieldMatching(IntendedCrmObject.Type, (Gp_CrmObjectType)currentCrmObj.CrmOjectTypeIndex, "BaseCrmObj:Type -> ");
        }


        protected abstract Task<Guid> CreateTypeAsync();


        private IEnumerable<BaseExtendedPropertyModel> CheckExtendedPropertiesAndGetUnexistedExtendedProperties(IEnumerable<ExtendedPropertyGetResultDto> currentProperties)
        {
            var detectedPair = IntendedCrmObject.Properties.Join(
                currentProperties,
                intendedProperty => intendedProperty.UserKey,
                currentProperty => currentProperty.UserKey,
                (intendedProperty, currentProperty) => Tuple.Create(intendedProperty, currentProperty)
                );

            foreach (var pair in detectedPair)
            {
                CheckFieldMatching(pair.Item1.UserKey, pair.Item2.UserKey, "BaseExtendedPropertyModel:UserKey -> ");
                CheckFieldMatching(pair.Item1.Type, (Gp_ExtendedPropertyType)pair.Item2.PropertyDisplayTypeIndex, "BaseExtendedPropertyModel:Type -> ");
            }

            return IntendedCrmObject.Properties.Except(detectedPair.Select(d => d.Item1));
        }

        private BaseExtendedPropertyCreationDto CreateExtendedPropertyCreationDto(BaseExtendedPropertyModel propertyModel)
        {
            switch (propertyModel.Type)
            {
                case Gp_ExtendedPropertyType.AutoNumber:
                    return propertyModel.ToAutoNumberExtendedPropertyCreationDto();

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
                    throw new NotFoundExtendedPropertyTypeException($"PropertyDisplayType: '{propertyModel.Type}'.");
            }
        }

        protected void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            ModelChecker.CheckFieldMatching(first, second, errorMessage);
        }

        public async Task<bool> CheckExistenceSchemaAsync()
        {
            ValidateInitialValidationModel();

            var searchedCrmObject = await SearchCrmObjectAsync();

            if (searchedCrmObject == null)
            {
                return false;
            }
            else
            {
                try
                {
                    CheckCrmObjectTypeBelongs(searchedCrmObject);

                    return true;
                }
                catch (MisMatchException)
                {
                    return false;
                }
            }
        }
    }
}
