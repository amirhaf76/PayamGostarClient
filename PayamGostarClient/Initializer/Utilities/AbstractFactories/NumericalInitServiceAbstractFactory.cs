using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.Utilities.Validator;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories
{
    internal class NumericalInitServiceAbstractFactory : BaseInitServiceAbstractFactory
    {
        internal NumericalInitServiceAbstractFactory(IPayamGostarApiClient payamGostarApiClient, IMatchingValidator matchingValidator) : base(payamGostarApiClient, matchingValidator)
        {
        }

        public override ICrmModelMatchingValidator CreateCrmModelMatchingValidator()
        {
            return new NumericCrmModelMatchingValidator(MatchingValidator);
        }
    }


}
