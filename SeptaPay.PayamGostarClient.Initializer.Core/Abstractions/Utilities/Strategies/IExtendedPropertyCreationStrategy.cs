using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies
{
    internal interface IExtendedPropertyCreationStrategy
    {
        Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid crmObjectTypeId, IEnumerable<BaseExtendedPropertyModel> newProperties);
        Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid crmObjectTypeId, IEnumerable<BaseExtendedPropertyModel> newProperties, IEnumerable<PropertyGroupGetResultDto> existedGroups);
    }
}
