using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    internal interface IExtendedPropertyMatchingValidator
    {
        IEnumerable<BaseExtendedPropertyModel> CheckMatchingAndGetNewExtendedProperties(
            IEnumerable<BaseExtendedPropertyModel> intentedProperties,
            IEnumerable<ExtendedPropertyGetResultDto> existedProperties);
    }
}