using PayamGostarClient.Initializer.Abstractions.Utilities.Strategies;
using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories
{
    internal interface IInitServiceAbstractFactory
    {
        IExtendedPropertyCreationStrategy CreateExtendedPropertyCreationStrategy();
        IGroupCreationStrategy CreateGroupCreationStrategy();
        IStageCreationStrategy CreateStageCreationStrategy();

        IStageMatchingValidator CreateStageMatchingValidator();
        IExtendedPropertyMatchingValidator CreateExtendedPropertyMatchingValidator();
        ICrmModelMatchingValidator CreateCrmModelMatchingValidator();
    }
}
