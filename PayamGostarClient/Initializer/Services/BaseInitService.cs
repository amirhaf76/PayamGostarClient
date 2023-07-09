using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.CreationStrategies;
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

        private readonly IExtendedPropertyCreationStrategy _propertyCreationStrategy;
        private readonly IGroupCreationStrategy _groupCreationStrategy;
        private readonly IStageCreationStrategy _stageCreationStrategy;


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

            _groupCreationStrategy = new GroupCreationStrategy(PropertyGroupApi);
            _propertyCreationStrategy = new ExtendedPropertyCreationStrategy(ExtendedPropertyApi, _groupCreationStrategy);
            _stageCreationStrategy = new StageCreationStrategy(CrmObjectTypeApi.StageApi);
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

            // await CheckStagesAndUpdateUnexistedStagesAsync(currentCrmObject.Id, currentCrmObject.Stages?.Select(x => x.ToStage()));
        }

        private void CheckCrmObjectTypeBelongs(CrmObjectTypeSearchResultDto currentCrmObject)
        {
            CheckBaseCrmObjectMatching(currentCrmObject);

            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(currentCrmObject.Properties);

            if (newProperties.Any())
            {
                throw new MisMatchException("There are some new properties.");
            }

            //var newStages = CheckStagesAndGetNewStages(currentCrmObject.Stages?.Select(x => x.ToStage()));

            //if (newStages.Any())
            //{
            //    throw new MisMatchException("There are some new stages.");
            //}
        }

        private async Task CreateCrmObjectTypeBelongs(Guid id)
        {
            await CreateGroupPropetiesAsync(id);

            await CreateExtendedPropertiesAsync(id);

            // await CreateStagesAsync(id);
        }


        private async Task CheckStagesAndUpdateUnexistedStagesAsync(Guid id, IEnumerable<Stage> currentStages)
        {
            List<Stage> newStages = CheckStagesAndGetNewStages(currentStages);

            await UpdateStagesAsync(id, newStages, currentStages.Max(x => x.Index) + 1);
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
            try
            {
                await _stageCreationStrategy.CreateStagesAsync(id, stages);
            }
            catch (NotFoundAtleastAFinalStageException e)
            {
                throw new StageCreationException($"A exception in creation of the model with '{IntendedCrmObject.Code}' code.", e);
            }
        }

        private async Task UpdateStagesAsync(Guid id, List<Stage> stages, int startIndex)
        {
            await _stageCreationStrategy.UpdateStagesAsync(id, stages, startIndex);
        }


        private async Task CreateGroupPropetiesAsync(Guid id)
        {
            await _groupCreationStrategy.CreateGroupPropetiesAsync(id, IntendedCrmObject.PropertyGroups);
        }


        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id)
        {
            return await _propertyCreationStrategy.CreateExtendedPropertiesAsync(id, IntendedCrmObject.Properties);
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties, IEnumerable<PropertyGroupGetResultDto> groups)
        {
            return await _propertyCreationStrategy.CreateExtendedPropertiesAsync(id, properties, groups);
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

        protected void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            ModelChecker.CheckFieldMatching(first, second, errorMessage);
        }

        
    }
}
