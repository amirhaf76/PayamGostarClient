using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    internal interface IExtendedPropertyMatchingValidator
    {
        IEnumerable<BaseExtendedPropertyModel> CheckMatchingAndGetNewExtendedProperties(
            IEnumerable<BaseExtendedPropertyModel> intentedProperties,
            IEnumerable<ExtendedPropertyGetResultDto> existedProperties);
    }
}