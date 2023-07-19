using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Utilities.Validator
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
