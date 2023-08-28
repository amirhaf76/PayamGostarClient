namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    public interface IMatchingValidator
    {
        void CheckFieldMatching<TField>(TField expected, TField actual, string errorMessage = "");
    }
}