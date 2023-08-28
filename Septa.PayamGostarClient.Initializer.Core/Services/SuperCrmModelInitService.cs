using Septa.PayamGostarClient.Initializer.Core.Abstractions.InitServices;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using Septa.PayamGostarClient.Initializer.Core.Utilities.CreationStrategies;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Validator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Services
{
    public class SuperCrmModelInitService : IInitService
    {
        private readonly IPayamGostarCrmObjectTypeApiClient _crmObjectType;
        private readonly IGroupCreationStrategy _groupCreation;
        private readonly IExtendedPropertyCreationStrategy _extendedProperty;
        private readonly IExtendedPropertyMatchingValidator _extendedPropertyMatchingValidator;
        private readonly SuperCrmModel _intentedCrmGeneralModel;


        public SuperCrmModelInitService(SuperCrmModel intentedCrmGeneralModel, IPayamGostarApiClient payamGostarApiClient)
        {
            _intentedCrmGeneralModel = intentedCrmGeneralModel;

            _crmObjectType = payamGostarApiClient.CustomizationApi.CrmObjectTypeApi;

            _groupCreation = new GroupCreationStrategy(payamGostarApiClient.CustomizationApi.PropertyGroupApi);
            _extendedProperty = new ExtendedPropertyCreationStrategy(payamGostarApiClient.CustomizationApi.ExtendedPropertyApi, _groupCreation);

            _extendedPropertyMatchingValidator = new ExtendedPropertyMatchingValidator();
        }


        public async Task<bool> CheckExistenceSchemaAsync()
        {
            try
            {
                var receivedAbstractCrmObject = await GetAbstractCrmObjectAsync();

                var newExtendedProperties = _extendedPropertyMatchingValidator.CheckMatchingAndGetNewExtendedProperties(
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

            var newExtendedProperties = _extendedPropertyMatchingValidator.CheckMatchingAndGetNewExtendedProperties(
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

            var receivedAbstractCrmObject = receivedAbstractCrmObjects?.FirstOrDefault();

            if (receivedAbstractCrmObject == null)
            {
                throw new NotFoundAbstractCrmObjectTypeException($"there is no crm object type with '{_intentedCrmGeneralModel.Type}' index!");
            }

            return receivedAbstractCrmObject;
        }

        private static IEnumerable<ExtendedPropertyGetResultDto> GetExtendedValueProperties(CrmObjectTypeSearchResultDto receivedAbstractCrmObject)
        {
            return receivedAbstractCrmObject.Properties
                .Where(p => p.PropertyTypeIndex == (int)Gp_PropertyType.ExtendedValue);
        }
    }
}
