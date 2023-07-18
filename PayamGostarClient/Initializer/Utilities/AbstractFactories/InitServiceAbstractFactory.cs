using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.Utilities.Validator;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories
{
    internal class InitServiceAbstractFactory : BaseInitServiceAbstractFactory
    {
        protected InitServiceAbstractFactory(IPayamGostarApiClient payamGostarApiClient, IMatchingValidator matchingValidator) : base(payamGostarApiClient, matchingValidator)
        {
        }

        public override ICrmModelMatchingValidator CreateCrmModelMatchingValidator()
        {
            return new CrmModelMatchingValidator(MatchingValidator);
        }
    }


}
