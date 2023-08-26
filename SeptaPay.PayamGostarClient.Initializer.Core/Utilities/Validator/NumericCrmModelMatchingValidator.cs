using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Validator
{
    internal class NumericCrmModelMatchingValidator : CrmModelMatchingValidator
    {
        internal NumericCrmModelMatchingValidator() : this(new MatchingValidator())
        {
        }

        internal NumericCrmModelMatchingValidator(IMatchingValidator modelChecker) : base(modelChecker)
        {
        }

        public override void CheckMatchingBaseCrmObject(BaseCRMModel baseCRMModel, CrmObjectTypeSearchResultDto existedCrmObj)
        {
            base.CheckMatchingBaseCrmObject(baseCRMModel, existedCrmObj);

            if (baseCRMModel is INumericalCrmModel numericalModel)
            {
                _modelChecker.CheckFieldMatching(existedCrmObj.NumberingTemplateId, numericalModel.NumberingTemplate.Id, "BaseCrmObj:NumberingTemplateId -> ");
            }
        }
    }
}
