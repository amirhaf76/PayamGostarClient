using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Validator;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.AbstractFactories
{
    internal class InitServiceAbstractFactory : BaseInitServiceAbstractFactory
    {
        internal InitServiceAbstractFactory(IPayamGostarApiClient payamGostarApiClient, IMatchingValidator matchingValidator) : base(payamGostarApiClient, matchingValidator)
        {
        }

        public override ICrmModelMatchingValidator CreateCrmModelMatchingValidator()
        {
            return new CrmModelMatchingValidator(MatchingValidator);
        }
    }


}
