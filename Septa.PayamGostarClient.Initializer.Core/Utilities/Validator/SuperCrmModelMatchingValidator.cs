using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Validator
{
    internal class SuperCrmModelMatchingValidator : CrmModelMatchingValidator
    {
        internal SuperCrmModelMatchingValidator() : this(new MatchingValidator())
        {
        }

        internal SuperCrmModelMatchingValidator(IMatchingValidator modelChecker) : base(modelChecker)
        {
        }

        public override void CheckMatchingBaseCrmObject(BaseCRMModel baseCRMModel, CrmObjectTypeSearchResultDto existedCrmObj)
        {
            _modelChecker.CheckFieldMatching(true, existedCrmObj.IsAbstract, "BaseCrmObj:isAbstract -> ");
            _modelChecker.CheckFieldMatching(baseCRMModel.Type, (Gp_CrmObjectType)existedCrmObj.CrmOjectTypeIndex, "BaseCrmObj:Type -> ");
        }
    }
}
