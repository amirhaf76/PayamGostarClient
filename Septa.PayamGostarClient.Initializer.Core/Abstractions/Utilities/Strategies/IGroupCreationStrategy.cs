﻿using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies
{
    internal interface IGroupCreationStrategy
    {
        Task<IEnumerable<PropertyGroup>> CreateGroupPropetiesAsync(Guid id, IEnumerable<PropertyGroup> groups);

        Task<int> CreateGroupPropetyAsync(Guid id, PropertyGroup group);
    }
}