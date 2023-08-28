using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    internal interface ICrmModelMatchingValidator
    {
        void CheckMatchingBaseCrmObject(BaseCRMModel baseCRMModel, CrmObjectTypeSearchResultDto existedCrmObj);
    }
}