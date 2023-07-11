using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.Strategies
{
    internal interface IExtendedPropertyCreationStrategy
    {
        Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid crmObjectTypeId, IEnumerable<BaseExtendedPropertyModel> newProperties);
        Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid crmObjectTypeId, IEnumerable<BaseExtendedPropertyModel> newProperties, IEnumerable<PropertyGroupGetResultDto> existedGroups);
    }
}
