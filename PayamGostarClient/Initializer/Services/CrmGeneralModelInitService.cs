using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.Comparers;
using PayamGostarClient.Initializer.CreationStrategies;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class CrmGeneralModelInitService : IInitService
    {
        private readonly IPayamGostarCrmObjectTypeApiClient _crmObjectType;
        private readonly IGroupCreationStrategy _groupCreation;
        private readonly IExtendedPropertyCreationStrategy _extendedProperty;
        private readonly IMatchingValidator _matchingValidator;
        private readonly CrmGeneralModel _intentedCrmGeneralModel;


        public CrmGeneralModelInitService(CrmGeneralModel intentedCrmGeneralModel, IPayamGostarApiClient payamGostarApiClient)
        {
            _intentedCrmGeneralModel = intentedCrmGeneralModel;

            _crmObjectType = payamGostarApiClient.CustomizationApi.CrmObjectTypeApi;

            _groupCreation = new GroupCreationStrategy(payamGostarApiClient.CustomizationApi.PropertyGroupApi);
            _extendedProperty = new ExtendedPropertyCreationStrategy(payamGostarApiClient.CustomizationApi.ExtendedPropertyApi, _groupCreation);

            _matchingValidator = new MatchingValidator();
        }


        public async Task<bool> CheckExistenceSchemaAsync()
        {
            try
            {
                var receivedAbstractCrmObject = await GetAbstractCrmObjectAsync();

                var newExtendedProperties = _matchingValidator.CheckMatchingAndGetNewExtendedProperties(
                    intentedProperties: _intentedCrmGeneralModel.Properties,
                    existedProperties: GetExtendedValueProperties(receivedAbstractCrmObject));

                if (newExtendedProperties.Any())
                {
                    return false;
                }
            }
            catch (MisMatchException)
            {
                return false;
            }

            return true;
        }

        public async Task InitAsync()
        {
            var receivedAbstractCrmObject = await GetAbstractCrmObjectAsync();

            var newExtendedProperties = _matchingValidator.CheckMatchingAndGetNewExtendedProperties(
                intentedProperties: _intentedCrmGeneralModel.Properties,
                existedProperties: GetExtendedValueProperties(receivedAbstractCrmObject));

            await _extendedProperty.CreateExtendedPropertiesAsync(
                crmObjectTypeId: receivedAbstractCrmObject.Id,
                newProperties: newExtendedProperties,
                existedGroups: receivedAbstractCrmObject.Groups);
        }


        private async Task<CrmObjectTypeSearchResultDto> GetAbstractCrmObjectAsync()
        {
            var request = new CrmObjectTypeSearchRequestDto
            {
                CrmOjectTypeIndex = (int)_intentedCrmGeneralModel.Type,
                IsAbstract = true,
            };

            var receivedAbstractCrmObjects = await _crmObjectType.SearchAsync(request);

            var receivedAbstractCrmObject = receivedAbstractCrmObjects.Result?.FirstOrDefault();

            if (receivedAbstractCrmObject == null)
            {
                throw new NotFoundAbstractCrmObjectTypeException($"there is no crm object type with '{_intentedCrmGeneralModel.Type}' index!");
            }

            return receivedAbstractCrmObject;
        }

        private static System.Collections.Generic.IEnumerable<ApiClient.Dtos.CrmObjectDtos.ExtendedPropertyGetResultDto> GetExtendedValueProperties(CrmObjectTypeSearchResultDto receivedAbstractCrmObject)
        {
            return receivedAbstractCrmObject.Properties
                .Where(p => p.PropertyTypeIndex == (int)Gp_PropertyType.ExtendedValue);
        }
    }
}
