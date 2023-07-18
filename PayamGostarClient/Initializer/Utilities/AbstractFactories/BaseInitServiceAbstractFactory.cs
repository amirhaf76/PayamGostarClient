using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.Utilities.CreationStrategies;
using PayamGostarClient.Initializer.Utilities.Validator;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories
{
    internal abstract class BaseInitServiceAbstractFactory : IInitServiceAbstractFactory
    {
        protected IPayamGostarApiClient PayamGostarApiClient { get; }
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
