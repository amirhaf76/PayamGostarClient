using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories
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
    }
}
