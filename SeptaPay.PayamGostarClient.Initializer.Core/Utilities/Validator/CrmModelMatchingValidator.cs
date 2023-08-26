using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Validator
{
    internal class CrmModelMatchingValidator : ICrmModelMatchingValidator
    {
        protected readonly IMatchingValidator _modelChecker;

        internal CrmModelMatchingValidator() : this(new MatchingValidator())
        {
        }

        internal CrmModelMatchingValidator(IMatchingValidator modelChecker)
        {
            _modelChecker = modelChecker;
        }


        public virtual void CheckMatchingBaseCrmObject(BaseCRMModel baseCRMModel, CrmObjectTypeSearchResultDto existedCrmObj)
        {
            _modelChecker.CheckFieldMatching(baseCRMModel.Code, existedCrmObj.Code, "BaseCrmObj:Code -> ");
            _modelChecker.CheckFieldMatching(baseCRMModel.Type, (Gp_CrmObjectType)existedCrmObj.CrmOjectTypeIndex, "BaseCrmObj:Type -> ");
        }
    }
}
