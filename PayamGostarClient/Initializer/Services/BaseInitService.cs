using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.Initializer.Abstractions.InitServices;
using PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Utilities.CreationStrategies;
using PayamGostarClient.Initializer.Utilities.Validator;
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
        private readonly IStageCreationStrategy _stageCreationStrategy;

        private readonly IStageMatchingValidator _stageMatchingValidator;
        private readonly IExtendedPropertyMatchingValidator _extendedPropertyMatchingValidator;
        private readonly ICrmModelMatchingValidator _crmModelMatchingValidator;

        private IPayamGostarCustomizationApiClient CustomizationApi { get; }

        protected IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi { get; }


        internal BaseInitService(T intendedCrmObject, IPayamGostarApiClient payamGostarApiClient, IInitServiceAbstractFactory factory)
        {
            IntendedCrmObject = intendedCrmObject;

            CustomizationApi = payamGostarApiClient.CustomizationApi;

            CrmObjectTypeApi = CustomizationApi.CrmObjectTypeApi;

            _propertyCreationStrategy = factory.CreateExtendedPropertyCreationStrategy();
            _stageCreationStrategy = factory.CreateStageCreationStrategy();

            _stageMatchingValidator = factory.CreateStageMatchingValidator();
            _extendedPropertyMatchingValidator = factory.CreateExtendedPropertyMatchingValidator();
            _crmModelMatchingValidator = factory.CreateCrmModelMatchingValidator();

        }


        public async Task InitAsync()
        {
            ValidateInitialValidationModel();

            var searchedCrmObject = await SearchCrmObjectTypeAsync();

            if (searchedCrmObject == null)
            {
                await CreateCrmObjectAndSetItsBelongsAsync();

                await CreateSuperCrmObjectTypeBelongs();
            }
            else
            {
                await CheckCrmObjectTypeBelongsAndInsert(searchedCrmObject);

                await CheckSuperCrmObjectTypeBelongsAndInsert();
            }
        }

        public async Task<bool> CheckExistenceSchemaAsync()
        {
            ValidateInitialValidationModel();

            var searchedCrmObject = await SearchCrmObjectTypeAsync();
            var searchedSuperCrmObject = await SearchSuperCrmObjectTypeAsync();

            if (searchedCrmObject == null)
            {
                return false;
            }
            else
            {
                try
                {
                    CheckCrmObjectTypeBelongs(searchedCrmObject);

                    CheckSuperCrmObjectTypeBelongs(searchedSuperCrmObject);

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

            var languageCultures = IntendedCrmObject.Name.Select(n => n.LanguageCulture.Trim().ToLower());

            if (languageCultures.Count() != languageCultures.Distinct().Count())
            {
                throw new CultureNamesException($"The crmObject model with '{IntendedCrmObject.Code}' has more than one recource value for one culture!");
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

            var propertyKeyGroups = IntendedCrmObject.Properties?.GroupBy(p => p.UserKey);

            foreach (var propertyKeyGroup in propertyKeyGroups)
            {
                if (propertyKeyGroup.Count() > 1)
                {
                    throw new NonUniqeUserKeyException($"In the crmObject with '{IntendedCrmObject.Code}', there are more than one userKey with \"{propertyKeyGroup.Key}\".");
                }
            }

            var isValidSuperModelGroups = IntendedCrmObject.Properties?
                .GroupBy(property => property.PropertyGroup)
                .All(groupAndItsProperties => groupAndItsProperties.GroupBy(property => property.DoesBelongToSuperCrmObjectType).Count() == 1) ?? true;

            if (!isValidSuperModelGroups)
            {
                var message = $"In the crmObject with '{IntendedCrmObject.Code}' code, there is atleast a group which have some super crm model type properites and some instance crm model type properites.";
                throw new InvalidSuperCrmModelGroupException(message);
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

            await CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(
                currentCrmObject.Id,
                GetNonSuperCrmModelProperties(),
                currentCrmObject.Properties,
                currentCrmObject.Groups);

            // await CheckStagesAndUpdateUnexistedStagesAsync(currentCrmObject.Id, currentCrmObject.Stages?.Select(x => x.ToStage()));
        }

        private async Task CheckSuperCrmObjectTypeBelongsAndInsert()
        {
            var superCrmModelProperties = GetSuperCrmModelProperties();

            if (superCrmModelProperties.Any())
            {
                var searchedSuperCrmObjectType = await SearchSuperCrmObjectTypeAsync();

                await CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(
                    searchedSuperCrmObjectType.Id,
                    superCrmModelProperties,
                    searchedSuperCrmObjectType.Properties,
                    searchedSuperCrmObjectType.Groups);
            }
        }

        private IEnumerable<BaseExtendedPropertyModel> GetSuperCrmModelProperties()
        {
            return IntendedCrmObject.Properties.Where(x => x.DoesBelongToSuperCrmObjectType);
        }

        private IEnumerable<BaseExtendedPropertyModel> GetNonSuperCrmModelProperties()
        {
            return IntendedCrmObject.Properties.Where(x => !x.DoesBelongToSuperCrmObjectType);
        }

        private void CheckCrmObjectTypeBelongs(CrmObjectTypeSearchResultDto currentCrmObject)
        {
            CheckBaseCrmObjectMatching(currentCrmObject);

            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(
                GetNonSuperCrmModelProperties(),
                currentCrmObject.Properties);

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

        private void CheckSuperCrmObjectTypeBelongs(CrmObjectTypeSearchResultDto superCrmObject)
        {
            CheckBaseCrmObjectMatching(superCrmObject);

            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(
                GetSuperCrmModelProperties(),
                superCrmObject.Properties);

            if (newProperties.Any())
            {
                throw new MisMatchException("There are some new properties which belong to super crm object type.");
            }
        }

        private async Task CreateCrmObjectTypeBelongs(Guid id)
        {
            await CreateExtendedPropertiesAsync(id, GetNonSuperCrmModelProperties());

            // await CreateStagesAsync(id);
        }

        private async Task CreateSuperCrmObjectTypeBelongs()
        {
            var superCrmModelProperties = GetSuperCrmModelProperties();

            if (superCrmModelProperties.Any())
            {
                var searchedSuperCrmObject = await SearchSuperCrmObjectTypeAsync();

                await CreateExtendedPropertiesAsync(searchedSuperCrmObject.Id, superCrmModelProperties);
            }
        }

        private async Task CheckStagesAndUpdateUnexistedStagesAsync(Guid id, IEnumerable<Stage> currentStages)
        {
            List<Stage> newStages = CheckStagesAndGetNewStages(currentStages);

            await UpdateStagesAsync(id, newStages, currentStages);
        }



        private async Task CheckExtendedPropertiesAndCreateUnexistedExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> propertyModels, IEnumerable<ExtendedPropertyGetResultDto> currentExtendedProperties, IEnumerable<PropertyGroupGetResultDto> groups)
        {
            var newProperties = CheckExtendedPropertiesAndGetUnexistedExtendedProperties(propertyModels, currentExtendedProperties);

            await CreateExtendedPropertiesAsync(id, newProperties, groups);
        }


        private async Task<CrmObjectTypeSearchResultDto> SearchCrmObjectTypeAsync()
        {
            var request = CreateCrmObjectSubTypeRequestDto(IntendedCrmObject);

            return await SearchCrmObjectTypeAsync(request);
        }

        private async Task<CrmObjectTypeSearchResultDto> SearchSuperCrmObjectTypeAsync()
        {
            var request = CreateSuperCrmObjectTypeSearchRequestDto(IntendedCrmObject);

            return await SearchCrmObjectTypeAsync(request);
        }

        private async Task<CrmObjectTypeSearchResultDto> SearchCrmObjectTypeAsync(CrmObjectTypeSearchRequestDto request)
        {
            Helper.Net.ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>> receivedCrmObjects = await CrmObjectTypeApi.SearchAsync(request);

            var receivedCrmObject = receivedCrmObjects.Result.FirstOrDefault();

            return receivedCrmObject;
        }


        private static CrmObjectTypeSearchRequestDto CreateCrmObjectSubTypeRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                Code = crmMode.Code,
                CrmOjectTypeIndex = (int)crmMode.Type,
            };
        }

        private static CrmObjectTypeSearchRequestDto CreateSuperCrmObjectTypeSearchRequestDto(BaseCRMModel crmMode)
        {
            return new CrmObjectTypeSearchRequestDto
            {
                CrmOjectTypeIndex = (int)crmMode.Type,
                IsAbstract = true,
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

        private async Task UpdateStagesAsync(Guid id, List<Stage> stages, IEnumerable<Stage> existedStages)
        {
            await _stageCreationStrategy.UpdateStagesAsync(id, stages, existedStages);
        }


        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties)
        {
            return await _propertyCreationStrategy.CreateExtendedPropertiesAsync(id, properties);
        }

        private async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties, IEnumerable<PropertyGroupGetResultDto> groups)
        {
            return await _propertyCreationStrategy.CreateExtendedPropertiesAsync(id, properties, groups);
        }


        private void CheckBaseCrmObjectMatching(CrmObjectTypeSearchResultDto existedCrmObj)
        {
            try
            {
                _crmModelMatchingValidator.CheckMatchingBaseCrmObject(IntendedCrmObject, existedCrmObj);
            }
            catch (MisMatchException e)
            {
                throw new MisMatchException($"Mismatch in crm model with '{IntendedCrmObject.Code}' code!", e);
            }
        }

        private IEnumerable<BaseExtendedPropertyModel> CheckExtendedPropertiesAndGetUnexistedExtendedProperties(IEnumerable<BaseExtendedPropertyModel> propertyModels, IEnumerable<ExtendedPropertyGetResultDto> existedProperties)
        {
            try
            {
                return _extendedPropertyMatchingValidator.CheckMatchingAndGetNewExtendedProperties(propertyModels, existedProperties);
            }
            catch (MisMatchException e)
            {
                throw new MisMatchException($"Mismatch in crm model with '{IntendedCrmObject.Code}' code!", e);
            }
        }

        private List<Stage> CheckStagesAndGetNewStages(IEnumerable<Stage> existedStages)
        {
            try
            {
                return _stageMatchingValidator.CheckMatchingAndGetNewStages(IntendedCrmObject.Stages, existedStages);
            }
            catch (MisMatchException e)
            {
                throw new MisMatchException($"Mismatch in crm model with '{IntendedCrmObject.Code}' code!", e);
            }
        }


        protected abstract Task<Guid> CreateTypeAsync();

    }
}
