using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.Validator
{
    public interface IMatchingValidator
    {
        IEnumerable<BaseExtendedPropertyModel> CheckMatchingAndGetNewExtendedProperties(
            IEnumerable<BaseExtendedPropertyModel> intentedProperties,
            IEnumerable<ExtendedPropertyGetResultDto> existedProperties);

        List<Stage> CheckMatchingAndGetNewStages(IEnumerable<Stage> intentedStages, IEnumerable<Stage> existedStages);

        void CheckMatchingBaseCrmObject(BaseCRMModel baseCRMModel, CrmObjectTypeSearchResultDto existedCrmObj);
    }
}