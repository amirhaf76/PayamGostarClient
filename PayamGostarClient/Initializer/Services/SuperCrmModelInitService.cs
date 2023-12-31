﻿using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.InitServices;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Utilities.CreationStrategies;
using PayamGostarClient.Initializer.Utilities.Validator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
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

            var receivedAbstractCrmObject = receivedAbstractCrmObjects.Result?.FirstOrDefault();

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
