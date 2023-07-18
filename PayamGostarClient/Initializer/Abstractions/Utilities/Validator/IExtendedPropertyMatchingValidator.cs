using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.Validator
{
    internal interface IExtendedPropertyMatchingValidator
    {
        IEnumerable<BaseExtendedPropertyModel> CheckMatchingAndGetNewExtendedProperties(
            IEnumerable<BaseExtendedPropertyModel> intentedProperties,
            IEnumerable<ExtendedPropertyGetResultDto> existedProperties);
    }
}