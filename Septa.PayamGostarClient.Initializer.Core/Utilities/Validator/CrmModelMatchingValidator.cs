using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Validator
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
