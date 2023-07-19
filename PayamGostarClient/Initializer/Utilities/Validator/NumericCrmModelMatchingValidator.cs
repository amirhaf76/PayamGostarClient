using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Search;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Utilities.Validator
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
