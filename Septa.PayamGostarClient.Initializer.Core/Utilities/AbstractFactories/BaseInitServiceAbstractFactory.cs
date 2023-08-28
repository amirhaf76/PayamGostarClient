using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.Utilities.CreationStrategies;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Validator;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.AbstractFactories
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

        public ICrmModelMatchingValidator CreateSuperCrmModelMatchingValidator()
        {
            return new SuperCrmModelMatchingValidator(MatchingValidator);
        }

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
