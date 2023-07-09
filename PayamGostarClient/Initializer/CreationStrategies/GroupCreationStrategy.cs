using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.Extensions;
using PayamGostarClient.Initializer.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.CreationStrategies
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

            return groupCreationResult.Result.Id;
        }
    }
}
