using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.CreationStrategies;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Validator;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.AbstractFactories
{
    internal abstract class BaseInitServiceAbstractFactory : IInitServiceAbstractFactory
    {
        public IPayamGostarApiClient PayamGostarApiClient { get; }

        protected IMatchingValidator MatchingValidator { get; }

        protected BaseInitServiceAbstractFactory(IPayamGostarApiClient payamGostarApiClient, IMatchingValidator matchingValidator)
        {
            PayamGostarApiClient = payamGostarApiClient;
            MatchingValidator = matchingValidator;
        }

        public virtual IExtendedPropertyCreationStrategy CreateExtendedPropertyCreationStrategy()
        {
            var groupCreationStrategy = CreateGroupCreationStrategy();

            return new ExtendedPropertyCreationStrategy(PayamGostarApiClient.CustomizationApi.ExtendedPropertyApi, groupCreationStrategy);
        }

        public virtual IGroupCreationStrategy CreateGroupCreationStrategy()
        {
            return new GroupCreationStrategy(PayamGostarApiClient.CustomizationApi.PropertyGroupApi);
        }

        public virtual IStageCreationStrategy CreateStageCreationStrategy()
        {
            return new StageCreationStrategy(PayamGostarApiClient.CustomizationApi.CrmObjectTypeApi.StageApi);
        }

        public abstract ICrmModelMatchingValidator CreateCrmModelMatchingValidator();

        public virtual IExtendedPropertyMatchingValidator CreateExtendedPropertyMatchingValidator()
        {
            return new ExtendedPropertyMatchingValidator(MatchingValidator);
        }

        public virtual IStageMatchingValidator CreateStageMatchingValidator()
        {
            return new StageMatchingValidator(MatchingValidator);
        }
    }


}
