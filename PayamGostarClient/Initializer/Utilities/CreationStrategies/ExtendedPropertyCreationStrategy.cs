using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Utilities.CreationStrategies
{
    internal class ExtendedPropertyCreationStrategy : IExtendedPropertyCreationStrategy
    {
        private readonly IPayamGostarExtendedPropertyApiClient _extendedPropertyApi;
        private readonly IGroupCreationStrategy _groupCreationStrategy;


        internal ExtendedPropertyCreationStrategy(IPayamGostarExtendedPropertyApiClient extendedPropertyApi, IGroupCreationStrategy groupCreationStrategy)
        {
            _extendedPropertyApi = extendedPropertyApi;
            _groupCreationStrategy = groupCreationStrategy;
        }


        public async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid crmObjectTypeId, IEnumerable<BaseExtendedPropertyModel> newProperties)
        {
            var createdPropertiesId = new List<Guid>();

            foreach (var property in newProperties)
            {
                property.CrmObjectTypeId = crmObjectTypeId.ToString();

                var propertyDto = CreateExtendedPropertyCreationDto(property);

                var response = await _extendedPropertyApi.CreateAsync(propertyDto);

                createdPropertiesId.Add(response.Result.Id);
            }

            return createdPropertiesId;
        }

        public async Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid crmObjectTypeId, IEnumerable<BaseExtendedPropertyModel> newProperties, IEnumerable<PropertyGroupGetResultDto> existedGroups)
        {
            var createdPropertiesId = new List<Guid>();

            var groupedPropertiesAndGroups = newProperties.GroupBy(p => p.PropertyGroup);

            foreach (var groupedPropertiesAndGroup in groupedPropertiesAndGroups)
            {
                await CheckAndCreateGroupIfDoesNotExist(crmObjectTypeId, existedGroups, groupedPropertiesAndGroup);

                foreach (var property in groupedPropertiesAndGroup)
                {
                    property.CrmObjectTypeId = crmObjectTypeId.ToString();

                    var propertyDto = CreateExtendedPropertyCreationDto(property);

                    var response = await _extendedPropertyApi.CreateAsync(propertyDto);

                    createdPropertiesId.Add(response.Result.Id);
                }
            }

            return createdPropertiesId;
        }


        private async Task<PropertyGroup> CheckAndCreateGroupIfDoesNotExist(Guid crmObjectTypeId, IEnumerable<PropertyGroupGetResultDto> existedGroups, IGrouping<PropertyGroup, BaseExtendedPropertyModel> groupedPropertiesAndGroup)
        {
            //fetch group by name
            var theGroup = existedGroups.Where(g => groupedPropertiesAndGroup.Key.Name.Any(xx => xx.Value == g.Name)).FirstOrDefault();

            if (theGroup == null)
            {
                // create group if not exist
                var gId = await _groupCreationStrategy.CreateGroupPropetyAsync(crmObjectTypeId, groupedPropertiesAndGroup.Key);

                groupedPropertiesAndGroup.Key.Id = gId;
            }
            else
            {
                groupedPropertiesAndGroup.Key.Id = theGroup.Id;
            }

            return groupedPropertiesAndGroup.Key;
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
    }
}
