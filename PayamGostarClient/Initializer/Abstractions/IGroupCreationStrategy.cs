using PayamGostarClient.Initializer.CrmModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    internal interface IGroupCreationStrategy
    {
        Task<IEnumerable<PropertyGroup>> CreateGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups);

        Task<int> CreateGroupPropetyAsync(Guid id, PropertyGroup group);
    }
}
