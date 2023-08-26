using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Validator;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.AbstractFactories
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
