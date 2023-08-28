using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.CreationStrategies
{
    internal class GroupCreationStrategy : IGroupCreationStrategy
    {
        private readonly IPayamGostarPropertyGroupApiClient _propertyGroupApi;


        internal GroupCreationStrategy(IPayamGostarPropertyGroupApiClient api)
        {
            _propertyGroupApi = api;
        }


        public async Task<IEnumerable<PropertyGroup>> CreateGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups)
        {
            foreach (var group in groups)
            {
                var gId = await CreateGroupPropetyAsync(id, group);

                group.Id = gId;
            }

            return groups;
        }

        public async Task<int> CreateGroupPropetyAsync(Guid id, PropertyGroup group)
        {
            var groupDto = group.CreatePropertyGroupCreationRequest(id);

            var groupCreationResult = await _propertyGroupApi.CreateAsync(groupDto);

            return groupCreationResult.Id;
        }
    }
}
