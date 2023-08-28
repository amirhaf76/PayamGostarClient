using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories
{
    internal interface IInitServiceAbstractFactory
    {
        IPayamGostarApiClient PayamGostarApiClient { get; }

        IExtendedPropertyCreationStrategy CreateExtendedPropertyCreationStrategy();
        IGroupCreationStrategy CreateGroupCreationStrategy();
        IStageCreationStrategy CreateStageCreationStrategy();

        IStageMatchingValidator CreateStageMatchingValidator();
        IExtendedPropertyMatchingValidator CreateExtendedPropertyMatchingValidator();
        ICrmModelMatchingValidator CreateCrmModelMatchingValidator();
        ICrmModelMatchingValidator CreateSuperCrmModelMatchingValidator();
    }
}
