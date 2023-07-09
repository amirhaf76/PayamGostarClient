using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    internal interface IExtendedPropertyCreationStrategy
    {
        Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties);
        Task<IEnumerable<Guid>> CreateExtendedPropertiesAsync(Guid id, IEnumerable<BaseExtendedPropertyModel> properties, IEnumerable<PropertyGroupGetResultDto> existedGroups);
    }
}
