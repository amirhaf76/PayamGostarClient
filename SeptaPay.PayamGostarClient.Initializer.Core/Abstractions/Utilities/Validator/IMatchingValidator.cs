namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator
{
    public interface IMatchingValidator
    {
        void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "");
    }
}